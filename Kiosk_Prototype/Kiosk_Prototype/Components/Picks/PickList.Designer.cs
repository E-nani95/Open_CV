namespace Kiosk_Prototype.Components.Picks
{
    partial class PickList
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.roundedPanel1 = new Kiosk_Prototype.Components.RoundedPanel();
            this.flpnl = new System.Windows.Forms.FlowLayoutPanel();
            this.roundedPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // roundedPanel1
            // 
            this.roundedPanel1.Controls.Add(this.flpnl);
            this.roundedPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.roundedPanel1.Location = new System.Drawing.Point(0, 0);
            this.roundedPanel1.Name = "roundedPanel1";
            this.roundedPanel1.Padding = new System.Windows.Forms.Padding(20);
            this.roundedPanel1.Size = new System.Drawing.Size(521, 437);
            this.roundedPanel1.TabIndex = 0;
            // 
            // flpnl
            // 
            this.flpnl.AutoScroll = true;
            this.flpnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpnl.Location = new System.Drawing.Point(20, 20);
            this.flpnl.Name = "flpnl";
            this.flpnl.Size = new System.Drawing.Size(481, 397);
            this.flpnl.TabIndex = 0;
            // 
            // PickList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.roundedPanel1);
            this.Name = "PickList";
            this.Size = new System.Drawing.Size(521, 437);
            this.roundedPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private RoundedPanel roundedPanel1;
        private System.Windows.Forms.FlowLayoutPanel flpnl;
    }
}
