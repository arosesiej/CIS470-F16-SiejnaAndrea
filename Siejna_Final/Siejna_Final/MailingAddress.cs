using System;
namespace Siejna_Final
{
	public class MailingAddress
	{
		private string _AddressType;
		private string _AddressLine1;
		private string _AddressLine2;
		private string _City;
		private string _State;
		private string _ZipCode;
		private string _PhoneNumber;

		public bool SetAddressType(string userAddressType)
		{
			bool success = false;

			userAddressType = userAddressType.ToLower();

			if (userAddressType == "home" || userAddressType == "business")
			{
				_AddressType = userAddressType;
				success = true;
			}

			return success;
		}

		public bool SetAddressLine1(string userAddressLine1)
		{
			bool success = false;

			if (userAddressLine1 != "")
			{
				_AddressLine1 = userAddressLine1;
				success = true;
			}

			return success;
		}

		public void SetAddressLine2(string userAddressLine2)
		{
			_AddressLine2 = userAddressLine2;
		}

		public bool SetCity(string userCity)
		{
			bool success = false;

			if (userCity != "")
			{
				_City = userCity;
				success = true;
			}

			return success;
		}

		public bool SetState(string userState)
		{
			bool success = false;

			if (userState != "")
			{
				_State = userState;
				success = true;
			}

			return success;
		}

		public bool SetZipCode(string userZipCode)
		{
			bool success = false;

			if (userZipCode != "")
			{
				_ZipCode = userZipCode;
				success = true;
			}

			return success;
		}

		public void SetPhoneNumber(string userPhoneNumber)
		{
			_PhoneNumber = userPhoneNumber;
		}

		public string GetAddressType()
		{
			return _AddressType;
		}

		public string GetAddressLine1()
		{
			return _AddressLine1;
		}

		public string GetAddressLine2()
		{
			return _AddressLine2;
		}

		public string GetCity()
		{
			return _City;
		}

		public string GetState()
		{
			return _State;
		}

		public string GetZipCode()
		{
			return _ZipCode;
		}

		public string GetPhoneNumber()
		{
			return _PhoneNumber;
		}

		public void Display()
		{
			Console.WriteLine("{0}", _AddressLine1);

			if (_AddressLine2 != "" && _AddressLine2 != null)
			{
				Console.WriteLine("{0}", _AddressLine2);
			}

			Console.WriteLine("{0}, {1} {2}", _City, _State, _ZipCode);
			Console.WriteLine("Phone Number: {0}", _PhoneNumber);
		}

		public void Setup()
		{
			Console.Clear();
			SetAddressType(AskHomeOrBusiness("What type of address is this (home or business)? ", "You must enter home or business."));
			SetAddressLine1(AskTextQuestion("What is Address Line 1? ", "Address Line 1 cannot be blank!", false));
			SetAddressLine2(AskTextQuestion("What is Address Line 2? ", "Address Line 2 must be valid input!", true));
			SetCity(AskTextQuestion("What is the city? ", "City cannot be blank!", false));
			SetState(AskTextQuestion("What is the state? ", "State cannot be blank!", false));
			SetZipCode(AskTextQuestion("What is the zip code? ", "Zip cannot be blank!", false));
			SetPhoneNumber(AskTextQuestion("What is the phone number? ", "Phone number must be valid input!", true));


		}




		private string AskTextQuestion(string question, string errorMessage, bool allowBlankInput)
		{
			bool success;
			string answer;
				
			do
			{
				success = true;
				Console.Clear();
				Console.Write(question);
				answer = Console.ReadLine();

				if (allowBlankInput == false && answer == "")
				{
					Console.WriteLine(errorMessage);
					Console.ReadKey(true);
					success = false;
				}

			} while (!success);

			return answer;
		}

		public string AskHomeOrBusiness(string question, string errorMessage)
		{
			bool success;
			string answer;

			do
			{
				success = true;
				Console.Clear();
				Console.Write(question);
				answer = Console.ReadLine();

				answer = answer.ToLower();

				if (answer == "")
				{
					Console.WriteLine(errorMessage);
					Console.ReadKey(true);
					success = false;
				}
				else
				{
					if (answer != "home" && answer != "business")
					{
						Console.WriteLine(errorMessage);
						Console.ReadKey(true);
						success = false;
					}
				}

			} while (!success);

			return answer;
		}

		public MailingAddress()
		{
		}



	}
}
