using EtlTool.Banks;

namespace EtlTool
{
    public partial class Form1 : Form
    {
        BaseBank bank = null;
        public Form1()
        {
            InitializeComponent();
          
            if (AppConstants.Bank == Enums.Companies.Abc.ToString())
            {
                bank = new AbcBank();
            }

            if (AppConstants.Bank == Enums.Companies.Pqr.ToString())
            {
                bank = new PqrBank();
            }
        }

        private void btnPerformEtl_Click(object sender, EventArgs e)
        {
            bank.PerformEtl();
        }
    }
}