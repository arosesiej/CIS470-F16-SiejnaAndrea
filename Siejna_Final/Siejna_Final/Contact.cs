using System;
using System.Collections.Generic;
            
namespace Siejna_Final
{
	public class Contact
	{
		private string _FirstName;
		private string _LastName;
		private string _PhoneNumber;
		private string _Email;
		public List<MailingAddress> _Addresses = new List<MailingAddress>();



		public string GetFirstName()
		{
			return _FirstName;
		}

		public bool SetFirstName(string userFirstName)
		{
			bool success = false;

			if (userFirstName != "")
			{
				_FirstName = userFirstName;
				success = true;
			}

			return success;
		}

		public string GetLastName()
		{
			return _LastName;
		}

		public bool SetLastName(string userLastName)
		{
			bool success = false;

			if (userLastName != "")
			{
				_LastName = userLastName;
				success = true;
			}

			return success;
		}

		public string GetPhoneNumber()
		{
			return _PhoneNumber;
		}

		public void SetPhoneNumber(string userPhoneNumber)
		{
			_PhoneNumber = userPhoneNumber;
		}


		public string GetEmail()
		{
			return _Email;
		}

		public void SetEmail(string userEmail)
		{
			_Email = userEmail;
		}

		public Contact()
		{
			
		}


		public void Display()
		{

			Console.WriteLine("{0} {1}", _FirstName, _LastName);

			if (_PhoneNumber != "" && _PhoneNumber != null)
			{
				Console.WriteLine("Phone: {0}", _PhoneNumber);
			}

			if (_Email != "" && _Email != null)
			{
				Console.WriteLine("Email: {0}", _Email);
			}

			Console.WriteLine();

			if (_Addresses.Count > 0)
			{
				
				for (int x = 0; x < _Addresses.Count; x++)
				{

					MailingAddress tempAddress = _Addresses[x];

					Console.WriteLine("Address {0}: ", x+1);
					Console.WriteLine("Type: {0} ", tempAddress.GetAddressType());
					tempAddress.Display();
					Console.WriteLine();

				}

			}
			else
			{
				Console.WriteLine("0 Addresses.");
			}


		}

	}
}
