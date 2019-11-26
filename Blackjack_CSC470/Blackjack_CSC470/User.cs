using System;

namespace Blackjack_CSC470
{
    [Serializable]
    public class User
    {
        public string UName, FName, LName, AddrZero, AddrOne, City, SecretQ;
        public int LastFour;
        private int _zipCode;
        private long _PhoneNo;
        private StateEnum _state;
        private byte[] _ccnHash, _ccvHash, _exprHash, _passHash, _secAnsHash;
        public string DisplayName
        {
            get
            {
                return string.Concat(FName, " ", LName);
            }
        }
        public readonly Guid guid;
        public User(string UName, string FName, string LName, string AddrZero, string AddrOne,
            string City, string GetState, int ZipCode, long GetPhoneNo, byte[] PassWd, byte[] CredCardNo,
            byte[] CCV, byte[] ExpDate, string SecrQues, byte[] SecrAnsw, int lastFour)
        {
            guid = Guid.NewGuid();
            this.UName = UName;
            _passHash = PassWd;
            this.FName = FName;
            this.LName = LName;
            this.AddrZero = AddrZero;
            this.AddrOne = AddrOne;
            this.City = City;
            _state = (StateEnum)Enum.Parse(typeof(StateEnum), GetState.Replace(" ", "_").ToLower());
            PhoneNo = GetPhoneNo;
            _zipCode = ZipCode;
            LastFour = lastFour;
            _ccnHash = CredCardNo;
            _ccvHash = CCV;
            _exprHash = ExpDate;
            SecretQ = SecrQues;
            _secAnsHash = SecrAnsw;
        }
        public void ChangePass(byte[] OldPass, byte[] NewPass)
        {
            if (PassWdMatch(OldPass) || SecretAnsMatch(OldPass))
                _passHash = NewPass;
            else
                throw new AccessViolationException("Password change attempt with invalid password!", (Exception)null);
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
        public long PhoneNo
        {
            get => _PhoneNo;
            set
            {
                if ((value < 1110000000) || (value > 9999999999))
                    throw new ArgumentOutOfRangeException("This is not a valid phone number.", (Exception)null);
                else
                    _PhoneNo = value;
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
        public bool PassWdMatch(byte[] PassWd)
        {
            if (_passHash.Length != PassWd.Length)
                return false;
            for (int counter = 0; counter < _passHash.Length; counter++)
            {
                if (_passHash[counter] != PassWd[counter])
                    return false;
            }
            return true;
        }
        public bool SecretAnsMatch(byte[] SecretAns)
        {
            if (SecretAns.Length != _secAnsHash.Length)
                return false;
            for (int counter = 0; counter < _secAnsHash.Length; counter++)
            {
                if (_secAnsHash[counter] != SecretAns[counter])
                    return false;
            }
            return true;
        }
        public override string ToString()
        {
            return DisplayName;
        }
        public void NewCC (byte[] newCard, int LFour, byte[] NewCCV, byte[] NewExpr)
        {
            _ccnHash = newCard;
            LastFour = LFour;
            _ccvHash = NewCCV;
            _exprHash = NewExpr;
        }
        public void NewSecQ (string NewQuest, byte[] NewAnsw)
        {
            SecretQ = NewQuest;
            _secAnsHash = NewAnsw;
        }
    }
}