using BeerMaster.Controllers;
using BeerMaster.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerMaster.Starter
{
    public class ProgramStarter
    {
        private Loader _loader;
        private DBController _dbc;
        private Settings _settings;
        private DB _db;
        private void Start()
        {
            try
            {
                _loader = new Loader();
                _loader.Show();

                _dbc = new DBController();
                bool dbLoaded = false;

                if (_dbc.LoadDB())
                    dbLoaded = true;
                else if (_dbc.CreateDB())
                    dbLoaded = true;

                if (dbLoaded)
                {
                    _db = new DB();
                    _settings = new Settings();
                    _settings.LoadSettings(_dbc, _db);

                    View.MainWindowView mainWindowView = new View.MainWindowView()
                    {
                        DataContext = new ViewModel.MainWindowViewModel(_settings, _dbc, _db)
                    };
                    mainWindowView.Show();
                    _loader.Close();

                }
                else
                {
                    // Obsługa błędów
                }
            } catch (Exception ex)
            {
                // Obsługa błędów
                try
                {
                    _loader.Close();
                    GC.Collect();
                }
                catch (Exception ex2) { GC.Collect(); }
            }
        }

        public ProgramStarter()
        {
            Start();
        }
    }
}
