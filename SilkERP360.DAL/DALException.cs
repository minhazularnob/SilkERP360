using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

/// <summary>
/// Summary description for SPMException
/// </summary>
namespace SilkERP360.DAL
{
    public class DALException : System.ApplicationException
    {

        #region MemberVariables
        private System.String m_strErrorMessage;
        private System.Int32 m_intErrorNumber;
        private System.Exception m_innerException;
        private System.String m_strSource;
        #endregion MemberVariables

        #region Properties
        public System.String ErrorMessage
        {
            get
            {
                return this.m_strErrorMessage;
            }
        }
        public System.Int32 ErrorNumber
        {
            get
            {
                return this.m_intErrorNumber;
            }
        }
        public new System.Exception InnerException
        {
            get
            {
                return this.m_innerException;
            }
        }
        public new System.String Source
        {
            get
            {
                return this.m_strSource;
            }
        }
        #endregion Properties

        #region Constructers
        public DALException()
        {
            this.m_intErrorNumber = 0;
            this.m_strErrorMessage = "";
            this.m_innerException = null;
            this.m_strSource = "";
        }
        public DALException(System.Exception SysException)
        {
            this.m_intErrorNumber = 0;
            this.m_strErrorMessage = SysException.Message;
            this.m_innerException = SysException.InnerException;
            this.m_strSource = SysException.Source;
        }
        public DALException(System.Int32 ErrorNumber, System.String ErrorMessage)
        {
            this.m_intErrorNumber = ErrorNumber;
            this.m_strErrorMessage = ErrorMessage;
            this.m_innerException = null;
            this.m_strSource = "";
        }
        #endregion Constructors

    }
}
