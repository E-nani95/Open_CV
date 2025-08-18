using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk_Prototype.Components
{
    public delegate void CountDownTickEventHandler(int remainingSeconds);
    [DefaultEvent("Tick")]
    public partial class CountDownTimer : Component
    {
        //남은 시간
        private int _remainingSeconds;
        private void Timer1_Tick(object sender, EventArgs e)
        {
            Tick?.Invoke(--_remainingSeconds);
            if (_remainingSeconds == 0) 
            { 
                CountDownEnded?.Invoke();
                timer1.Stop();
            }
        }

        public event CountDownTickEventHandler Tick;
        public event Action CountDownEnded;//반환값이 없어서 가능

        // CountDownTimer 직접객체 생성
        public CountDownTimer()
        {
            InitializeComponent();
        }

        // 디자이너 위에 올려주면 하단의 생성자 구분이 실행됨
        public CountDownTimer(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            //1초마다 호출됨
            // 그걸 알리기 위해 이벤트도 만들어줌
            timer1.Tick += Timer1_Tick;
        }

        [DefaultValue(30), Description("카운트 다운 시작 시간")]
        public int WaitSeconds { get; set; } = 30;

        public void Start() 
        { 
            _remainingSeconds = WaitSeconds;
            Tick?.Invoke(_remainingSeconds);// 이렇게 설정해주는 이유는 타이머가 1초후에 호출되기때문에 맨처음에 30초가 들어가면(_remainingSeconds) 30초부터 시작
            timer1.Start();
        }

        public void Stop() 
        { 
            timer1.Stop(); 
        }

    }
}
