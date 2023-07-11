using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BeerMaster.Starter
{
    /// <summary>
    /// Logika interakcji dla klasy Starter.xaml
    /// </summary>
    public partial class Starter : Window
    {
        public Starter()
        {
            ProgramStarter programStarter = new ProgramStarter();
            InitializeComponent();
            this.Close();
        }
    }
}
