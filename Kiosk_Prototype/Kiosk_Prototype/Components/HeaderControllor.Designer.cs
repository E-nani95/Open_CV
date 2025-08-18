namespace Kiosk_Prototype.Components
{
    partial class HeaderControllor
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
            this.HeaderTitle = new System.Windows.Forms.Label();
            this.HeaderDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // HeaderTitle
            // 
            this.HeaderTitle.AutoSize = true;
            this.HeaderTitle.Font = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.HeaderTitle.Location = new System.Drawing.Point(34, 28);
            this.HeaderTitle.Name = "HeaderTitle";
            this.HeaderTitle.Size = new System.Drawing.Size(194, 32);
            this.HeaderTitle.TabIndex = 0;
            this.HeaderTitle.Text = "HeaderTitle";
            // 
            // HeaderDescription
            // 
            this.HeaderDescription.AutoSize = true;
            this.HeaderDescription.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.HeaderDescription.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.HeaderDescription.Location = new System.Drawing.Point(35, 90);
            this.HeaderDescription.Name = "HeaderDescription";
            this.HeaderDescription.Size = new System.Drawing.Size(255, 28);
            this.HeaderDescription.TabIndex = 1;
            this.HeaderDescription.Text = "HeaderDescription";
            // 
            // HeaderControllor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.HeaderDescription);
            this.Controls.Add(this.HeaderTitle);
            this.Name = "HeaderControllor";
            this.Size = new System.Drawing.Size(545, 167);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label HeaderTitle;
        private System.Windows.Forms.Label HeaderDescription;
    }
}
