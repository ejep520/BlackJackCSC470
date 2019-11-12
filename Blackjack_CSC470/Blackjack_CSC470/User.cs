using System;
using System.Text;
using System.Security.Cryptography;

public class User
{
    private string _fname, _lname, _addrZero, _addrOne, _city, _passwd,
                    _credCardNo, _ccv, _expDate, _secrQues, _secrAnsw;
    private int _state, _zipCode;
    private byte[] _ccnHash, _ccvHash, _passHash, _secAnsHash;
    public string _dname
    {
        get
        {
            return string.Concat(this._fname, " ", this._lname);
        }
    }
    SHA512 sHA = new SHA512Managed();
    public readonly Guid guid;
    private UnicodeEncoding ue = new UnicodeEncoding();
	public User(string FName, string LName, string AddrZero, string AddrOne,
        string City, int State, int ZipCode, string PassWd, string CredCardNo,
        string CCV, string ExpDate, string SecrQues, string SecrAnsw)
	{
        sHA.Initialize();
        guid = new Guid();
        _fname = FName;
        _lname = LName;
        _addrZero = AddrZero;
        _addrOne = AddrOne;
        _city = City;
        _passwd = PassWd;
        _credCardNo = CredCardNo;
        _ccv = CCV;
        _expDate = ExpDate;
        _secrQues = SecrQues;
        _secrAnsw = SecrAnsw;
        _ccnHash = sHA.ComputeHash(ue.GetBytes());
	}

}
