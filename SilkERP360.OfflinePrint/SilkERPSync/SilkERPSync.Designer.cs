namespace SilkERPSync
{
    partial class SilkERPSync
    {
        private System.Timers.Timer m_obj_SecondTimer;
        private const System.String SILKERP_DATABASE_CONNECTION_STRING_ORCL = @"Data Source=db; User Id=silkerp; Password=silkerp;";
        private const System.String BIOMETRIC_DATABASE_CONNECTION_STRING_SQL = @"Data Source=192.168.48.10;Initial Catalog=CCFTCentral;Uid=system;Password=cardax";
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // 
            // SilkERPSync
            // 
            
        }

        #endregion

    }
}
