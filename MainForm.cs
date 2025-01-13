using SchoolBellSystem.Infrastructure;
using SchoolBellSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBellSystem
{
    public partial class MainForm : Form
    {
        private readonly AudioPlayer _audioPlayer;
        private readonly JsonScheduleRepository _repository;
        private SchoolSchedule _schedule;

        // เก็บสถานะว่าเคยเล่นเสียงเริ่มคาบ/หมดคาบไปแล้วหรือยัง
        private Dictionary<int, (bool startPlayed, bool endPlayed)> _playedStatus;

        public MainForm()
        {
            InitializeComponent();

            _audioPlayer = new AudioPlayer();
            _repository = new JsonScheduleRepository("schedule.json");
            _schedule = _repository.Load();

            _playedStatus = new Dictionary<int, (bool startPlayed, bool endPlayed)>();

            // เริ่มทำงาน Timer (กำหนดไว้ 1 วินาทีใน Designer)
            bellTimer.Start();

            LoadSchedule();
        }

        private void LoadSchedule()
        {
            lstPeriods.Items.Clear();

            for (int i = 0; i < _schedule.Periods.Count; i++)
            {
                var period = _schedule.Periods[i];
                lstPeriods.Items.Add(
                    $"{period.Name} | Start: {period.StartTime:hh\\:mm}" +
                    $" | Dur: {period.Duration} min" +
                    $" | End: {period.EndTime:hh\\:mm}"
                );

                // ถ้าใน _playedStatus ยังไม่มีค่า ให้เริ่มเป็น (false,false)
                if (!_playedStatus.ContainsKey(i))
                {
                    _playedStatus[i] = (false, false);
                }
            }

            lblBellSound.Text = $"Bell Sound: {_schedule.BellSound ?? "Not Selected"}";
        }

        private void btnAddPeriod_Click(object sender, EventArgs e)
        {
            // 1) ตรวจสอบ Duration
            if (!int.TryParse(txtDuration.Text, out int duration) || duration <= 0)
            {
                MessageBox.Show("Invalid Duration. Must be positive integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2) หา StartTime
            TimeSpan startTime;
            if (_schedule.Periods.Count == 0)
            {
                // ถ้าไม่มีคาบเลย ให้ผู้ใช้กรอก start time เอง
                try
                {
                    startTime = TimeSpan.Parse(txtStartTime.Text);
                }
                catch
                {
                    MessageBox.Show("Invalid Start Time format. Use HH:mm.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                // มีคาบก่อนหน้า → StartTime = EndTime ของคาบสุดท้าย
                var lastPeriod = _schedule.Periods.Last();
                startTime = lastPeriod.EndTime;
            }

            // 3) สร้าง Period ใหม่
            var newPeriod = new ClassPeriod
            {
                Name = $"Period {_schedule.Periods.Count + 1}",
                StartTime = startTime,
                Duration = duration
            };

            // 4) เพิ่มลงตาราง
            _schedule.Periods.Add(newPeriod);
            _repository.Save(_schedule);

            // อัปเดตสถานะ
            _playedStatus[_schedule.Periods.Count - 1] = (false, false);

            LoadSchedule();
        }

        private void btnRemovePeriod_Click(object sender, EventArgs e)
        {
            if (lstPeriods.SelectedIndex >= 0)
            {
                _schedule.Periods.RemoveAt(lstPeriods.SelectedIndex);
                _repository.Save(_schedule);

                RebuildPlayedStatus();
                LoadSchedule();
            }
        }

        private void RebuildPlayedStatus()
        {
            _playedStatus.Clear();
            for (int i = 0; i < _schedule.Periods.Count; i++)
            {
                _playedStatus[i] = (false, false);
            }
        }

        private void btnSelectSound_Click(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog
            {
                Filter = "Audio Files (*.wav;*.mp3)|*.wav;*.mp3"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _schedule.BellSound = dialog.FileName;
                _repository.Save(_schedule);
                LoadSchedule();
            }
        }

        private void btnPlaySound_Click(object sender, EventArgs e)
        {
            // ทดสอบเล่นเสียงทันที
            _audioPlayer.Play(_schedule.BellSound);
        }

        private void bellTimer_Tick(object sender, EventArgs e)
        {
            // 1) แสดงเวลาปัจจุบัน
            lblCurrentTime.Text = $"Current Time: {DateTime.Now:HH:mm:ss}";

            // 2) ตรวจสอบเวลาเพื่อเล่นเสียงอัตโนมัติ
            CheckBellTimes();
        }

        private void CheckBellTimes()
        {
            if (string.IsNullOrEmpty(_schedule.BellSound)) return;

            var now = DateTime.Now.TimeOfDay;

            for (int i = 0; i < _schedule.Periods.Count; i++)
            {
                var period = _schedule.Periods[i];
                var status = _playedStatus[i];

                // เวลาเริ่มคาบ
                if (!status.startPlayed && now >= period.StartTime)
                {
                    _audioPlayer.Play(_schedule.BellSound);
                    _playedStatus[i] = (true, status.endPlayed);
                }

                // เวลาหมดคาบ
                if (!status.endPlayed && now >= period.EndTime)
                {
                    _audioPlayer.Play(_schedule.BellSound);
                    _playedStatus[i] = (status.startPlayed, true);
                }
            }
        }
    }
}