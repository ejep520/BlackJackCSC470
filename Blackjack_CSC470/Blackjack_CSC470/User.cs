using System;

namespace Blackjack_CSC470
{
    [Serializable]
    public class User
    {
        private string _fname, _lname, _addrZero, _addrOne, _city, _secrQues, _uname;
        private int _zipCode, _lastFour;
        private StateEnum _state;
        private byte[] _ccnHash, _ccvHash, _exprHash, _passHash, _secAnsHash;
        public string DisplayName
        {
            get
            {
                return string.Concat(_fname, " ", _lname);
            }
        }
        public readonly Guid guid;
        public User(string UName, string FName, string LName, string AddrZero, string AddrOne,
            string City, string GetState, int ZipCode, byte[] PassWd, byte[] CredCardNo,
            byte[] CCV, byte[] ExpDate, string SecrQues, byte[] SecrAnsw, int lastFour)
        {
            guid = Guid.NewGuid();
            _uname = UName;
            _fname = FName;
            _lname = LName;
            _addrZero = AddrZero;
            _addrOne = AddrOne;
            _city = City;
            _state = (StateEnum)Enum.Parse(typeof(StateEnum), GetState.Replace(" ", "_").ToLower());
            _zipCode = ZipCode;
            _secrQues = SecrQues;
            _lastFour = lastFour;
            _ccnHash = CredCardNo;
            _ccvHash = CCV;
            _exprHash = ExpDate;
            _passHash = PassWd;
            _secAnsHash = SecrAnsw;
        }
        public string UName
        {
            get => _uname;
            set => _uname = value;
        }
        public string UserPass
        {
            get => "*****";
        }
        public void ChangePass(byte[] OldPass, byte[] NewPass)
        {
            if (_passHash == OldPass)
                _passHash = NewPass;
            else
                throw new AccessViolationException("Password change attempt with invalid password!", (Exception)null);
        }
        public string FName
        {
            get => _fname;
            set => _fname = value;
        }
        public string LName
        {
            get => _lname;
            set => _lname = value;
        }
        public string AddrZero
        {
            get => _addrZero;
            set => _addrZero = value;
        }
        public string AddrOne
        {
            get => _addrOne;
            set => _addrOne = value;
        }
        public string City
        {
            get => _city;
            set => _city = value;
        }
        public string State
        {
            get => _state.ToString().Replace("_", " ").ToUpperInvariant();
            set => _state = (StateEnum)Enum.Parse(typeof(StateEnum), value.Replace(" ", "_"), true);
        }
        public string ZipCode
        {
            get => (_zipCode.ToString().Length == 9) ? _zipCode.ToString().Insert(5, "-") : _zipCode.ToString();
            set
            {
                if ((value.Length == 10) && value.Contains("-"))
                {
                    _zipCode = int.Parse(value.Replace("-", string.Empty));
                }
                else if ((value.Length == 9) || (value.Length == 5))
                {
                    _zipCode = int.Parse(value);
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Invalid zip code passed.", (Exception)null);
                }
            }
        }
        public enum StateEnum
        {
            alabama,
            alaska,
            arizona,
            arkansas,
            california,
            colorado,
            connecticut,
            deleware,
            florida,
            georgia,
            hawaii,
            idaho,
            illinois,
            indiana,
            iowa,
            kansas,
            kentucky,
            louisiana,
            maine,
            maryland,
            massachusetts,
            michigan,
            minnesota,
            mississippi,
            missouri,
            montana,
            nebraska,
            nevada,
            new_hampshire,
            new_jersey,
            new_mexico,
            new_york,
            north_carolina,
            north_dakota,
            ohio,
            oklahoma,
            oregon,
            pennsylvania,
            rhode_island,
            south_carolina,
            south_dakota,
            tennessee,
            texas,
            utah,
            vermont,
            virginia,
            washington,
            west_virginia,
            wisconsin,
            wyoming,
            district_of_columbia,
            apo,
            fpo,
            american_samoa,
            guam,
            northern_mariana_islands,
            puerto_rico,
            us_virgin_islands
        }
        public string LastFour
        {
            get => string.Concat("*****", _lastFour);
        }
        public bool PassWdMatch(byte[] PassWd)
        {
            for (int counter = 0; counter < _passHash.Length; counter++)
            {
                if (_passHash[counter] != PassWd[counter])
                    return false;
            }
            return true;
        }
        public override string ToString()
        {
            return guid.ToString();
        }
    }
}