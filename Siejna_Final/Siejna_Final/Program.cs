using System;
using System.Collections.Generic;
using System.IO;

namespace Siejna_Final
{
	class MainClass
	{
		private List<Contact> Contacts = new List<Contact>();

		public static void Main(string[] args)
		{
			MainClass myProgram = new MainClass();
			myProgram.Run();
		}

		private void Run()
		{
			DisplayMainMenu();
		}

		private void DisplayMainMenu()
		{


			bool isTimeToQuit = false;
			ConsoleKey userKey;

			do
			{
				Console.Clear();
				Console.WriteLine("(V)iew Contacts");
				Console.WriteLine("(M)odify Contacts");
				Console.WriteLine("(A)dd a Contact");
				Console.WriteLine("(D)elete a Contact");
				Console.WriteLine("(I)mport Contacts From File");
				Console.WriteLine("(E)xport Contacts to File");
				Console.WriteLine("(Q)uit");
				Console.WriteLine();
				userKey = Console.ReadKey(true).Key;


					switch (userKey)
					{
						case ConsoleKey.V:
							ViewContacts();
							break;
						case ConsoleKey.M:
							ModifyContacts();
							break;
						case ConsoleKey.A:
							AddContacts();
							break;
						case ConsoleKey.D:
							DeleteContacts();
							break;
						case ConsoleKey.I:
							ImportContacts();
							break;
						case ConsoleKey.E:
							ExportContacts();
							break;
						case ConsoleKey.Q:
							isTimeToQuit = true;
							break;
						default:
							Console.WriteLine("Please enter a valid command!");
							break;
					}


				



			} while (!isTimeToQuit);

			Console.WriteLine("Time to quit!");

		}

		public void ViewContacts()
		{
			bool quit = false;
			int contactIndex = 0;
			int contactToJumpTo;

			if (Contacts.Count > 0)
			{
				do
				{
					Console.Clear();
					Console.WriteLine("< (P)revious | > (N)ext | (J)ump | (Q)uit");
					Console.WriteLine("=========================================");
					Console.WriteLine("Viewing Contact {0} of {1}", contactIndex + 1, Contacts.Count);
					Console.WriteLine();
					Contacts[contactIndex].Display();

					switch (Console.ReadKey(true).Key)
					{
						case ConsoleKey.N:
						case ConsoleKey.RightArrow:
							contactIndex++;
							if (contactIndex == Contacts.Count)
							{
								contactIndex--;
							}
							break;

						case ConsoleKey.P:
						case ConsoleKey.LeftArrow:
							contactIndex--;
							if (contactIndex == -1)
							{
								contactIndex++;
							}
							break;

						case ConsoleKey.J:
							contactToJumpTo = AskNumericQuestion("Type a contact to jump to [1 - " + Contacts.Count + "]: ", "Type in a valid number", 1, Contacts.Count);
							contactIndex = contactToJumpTo - 1;
							break;
							

						case ConsoleKey.Q:
							quit = true;
							break;
							
					}

				} while (quit == false);

			}
			else
			{
				Console.WriteLine("There are no contacts in the contact list!");
				Console.ReadKey(true);
			}

		}

		public void ModifyContacts()
		{
			bool quit = false;
			int contactIndex = 0;
			int contactToJumpTo;

			if (Contacts.Count > 0)
			{
				do
				{
					Console.Clear();
					Console.WriteLine("< (P)revious | > (N)ext | (J)ump | (M)odify | (Q)uit");
					Console.WriteLine("=========================================");
					Console.WriteLine("Viewing Contact {0} of {1}", contactIndex + 1, Contacts.Count);
					Console.WriteLine();
					Contacts[contactIndex].Display();

					switch (Console.ReadKey(true).Key)
					{
						case ConsoleKey.N:
						case ConsoleKey.RightArrow:
							contactIndex++;
							if (contactIndex == Contacts.Count)
							{
								contactIndex--;
							}
							break;

						case ConsoleKey.P:
						case ConsoleKey.LeftArrow:
							contactIndex--;
							if (contactIndex == -1)
							{
								contactIndex++;
							}
							break;

						case ConsoleKey.J:
							contactToJumpTo = AskNumericQuestion("Type a contact to jump to [1 - " + Contacts.Count + "]: ", "Type in a valid number", 1, Contacts.Count);
							contactIndex = contactToJumpTo - 1;
							break;

						case ConsoleKey.M:
							Console.Clear();


							Console.WriteLine("First Name: {0} - Is this correct? (Y/N)", Contacts[contactIndex].GetFirstName());

							if (Console.ReadKey(true).Key == ConsoleKey.N)
							{
								Contacts[contactIndex].SetFirstName(AskTextQuestion("Enter contact first name: ", "First name cannot be blank!", false));
							}



							Console.WriteLine("Last Name: {0} - Is this correct? (Y/N)", Contacts[contactIndex].GetLastName());

							if (Console.ReadKey(true).Key == ConsoleKey.N)
							{
								Contacts[contactIndex].SetLastName(AskTextQuestion("Enter contact last name: ", "Last name cannot be blank!", false));
							}


							Console.WriteLine("E-mail: {0} - Is this correct? (Y/N)", Contacts[contactIndex].GetEmail());

							if (Console.ReadKey(true).Key == ConsoleKey.N)
							{
								Contacts[contactIndex].SetEmail(AskTextQuestion("Enter contact e-mail: ", "E-mail must be valid!", true));
							}


							Console.WriteLine("Phone Number: {0} - Is this correct? (Y/N)", Contacts[contactIndex].GetPhoneNumber());

							if (Console.ReadKey(true).Key == ConsoleKey.N)
							{
								Contacts[contactIndex].SetPhoneNumber(AskTextQuestion("Enter contact phone number: ", "Phone number must be valid!", true));
							}




							for (int addressIndex = 0; addressIndex < Contacts[contactIndex]._Addresses.Count; addressIndex++)
							{
								MailingAddress tempAddress = Contacts[contactIndex]._Addresses[addressIndex];
								tempAddress.Display();


								Console.WriteLine();

								bool validInput = false;

								do
								{
									Console.WriteLine("Keep this address? (Y/N)");

									ConsoleKey userResponse = Console.ReadKey(true).Key;

									Console.Clear();

									switch (userResponse)
									{
										case ConsoleKey.Y:

											Console.WriteLine("Address Type: {0} - Is this correct? (Y/N)", tempAddress.GetAddressType());

											if (Console.ReadKey(true).Key == ConsoleKey.N)
											{
												tempAddress.SetAddressType(tempAddress.AskHomeOrBusiness("What type of address is this (home or business)? ", "You must enter home or business."));
											}

											Console.WriteLine("Address Line 1: {0} - Is this correct? (Y/N)", tempAddress.GetAddressLine1());

											if (Console.ReadKey(true).Key == ConsoleKey.N)
											{
												tempAddress.SetAddressLine1(AskTextQuestion("What is Address Line 1? ", "Address Line 1 cannot be blank!", false));
											}

											Console.WriteLine("Address Line 2: {0} - Is this correct? (Y/N)", tempAddress.GetAddressLine2());

											if (Console.ReadKey(true).Key == ConsoleKey.N)
											{
												tempAddress.SetAddressLine2(AskTextQuestion("What is Address Line 2? ", "", true));
											}

											Console.WriteLine("City: {0} - Is this correct? (Y/N)", tempAddress.GetCity());

											if (Console.ReadKey(true).Key == ConsoleKey.N)
											{
												tempAddress.SetCity(AskTextQuestion("What is the city? ", "City cannot be blank!", false));
											}

											Console.WriteLine("State: {0} - Is this correct? (Y/N)", tempAddress.GetState());

											if (Console.ReadKey(true).Key == ConsoleKey.N)
											{
												tempAddress.SetState(AskTextQuestion("What is the state? ", "State cannot be blank!", false));
											}

											Console.WriteLine("ZipCode: {0} - Is this correct? (Y/N)", tempAddress.GetZipCode());

											if (Console.ReadKey(true).Key == ConsoleKey.N)
											{
												tempAddress.SetZipCode(AskTextQuestion("What is the zip code? ", "Zip cannot be blank!", false));
											}

											Console.WriteLine("Phone Number: {0} - Is this correct? (Y/N)", tempAddress.GetPhoneNumber());

											if (Console.ReadKey(true).Key == ConsoleKey.N)
											{
												tempAddress.SetPhoneNumber(AskTextQuestion("What is the phone number? ", "Phone number must be valid input!", true));
											}


											validInput = true;
											break;

										case ConsoleKey.N:
											Contacts[contactIndex]._Addresses.RemoveAt(addressIndex);
											Console.WriteLine("Address removed.");
											addressIndex--;
											validInput = true;
											break;


										default:
											Console.WriteLine("Not valid input! Enter Y to Keep or N to Delete");
											break;

									}

								} while (!validInput);



							} // END ADDRESS LOOP

							bool endAddMailingAddress = false;

							do
							{

								Console.WriteLine("Do you have a mailing address to add to this contact? (Y/N)");

								if (Console.ReadKey(true).Key == ConsoleKey.Y)
								{
									MailingAddress tempAddress = new MailingAddress();
									tempAddress.Setup();

									Contacts[contactIndex]._Addresses.Add(tempAddress);

								}
								else
								{
									endAddMailingAddress = true;
								}

							} while (!endAddMailingAddress);



							break;

						case ConsoleKey.Q:
							quit = true;
							break;

					}

				} while (quit == false);

			}
			else
			{
				Console.WriteLine("There are no contacts in the contact list!");
				Console.ReadKey(true);

			}
		}

		public void AddContacts()
		{
			Contact tempContact = new Contact();
			tempContact.SetFirstName(AskTextQuestion("Enter contact first name: ", "First name cannot be blank!", false));
			tempContact.SetLastName(AskTextQuestion("Enter contact last name: ", "Last name cannot be blank!", false));
			tempContact.SetEmail(AskTextQuestion("Enter contact e-mail: ", "E-mail must be valid!", true));
			tempContact.SetPhoneNumber(AskTextQuestion("Enter contact phone number: ", "Phone number must be valid!", true));

			bool quit = false;

			do
			{
				Console.WriteLine("Do you have an address to add to this contact? (Y/N)");

				if (Console.ReadKey(true).Key == ConsoleKey.Y)
				{
					MailingAddress tempMailingAddress = new MailingAddress();
					tempMailingAddress.Setup();
					tempContact._Addresses.Add(tempMailingAddress);
				}
				else
				{
					quit = true;
				}

			} while (quit == false);

			tempContact.Display();

			Console.WriteLine("Press 'Y' to add the contact to the contact list");

			if (Console.ReadKey(true).Key == ConsoleKey.Y)
			{
				Contacts.Add(tempContact);
			}
			else
			{
				Console.WriteLine("Contact was not added to contact list.");
				Console.ReadKey(true);
			}

		}

		public void DeleteContacts()
		{
			bool quit = false;
			int contactIndex = 0;
			int contactToJumpTo;

			if (Contacts.Count > 0)
			{
				do
				{
					Console.Clear();
					Console.WriteLine("< (P)revious | > (N)ext | (J)ump | (DEL)ete | (Q)uit");
					Console.WriteLine("=========================================");
					Console.WriteLine("Viewing Contact {0} of {1}", contactIndex + 1, Contacts.Count);
					Console.WriteLine();
					Contacts[contactIndex].Display();

					switch (Console.ReadKey(true).Key)
					{
						case ConsoleKey.N:
						case ConsoleKey.RightArrow:
							contactIndex++;
							if (contactIndex == Contacts.Count)
							{
								contactIndex--;
							}
							break;

						case ConsoleKey.P:
						case ConsoleKey.LeftArrow:
							contactIndex--;
							if (contactIndex == -1)
							{
								contactIndex++;
							}
							break;

						case ConsoleKey.J:
							contactToJumpTo = AskNumericQuestion("Type a contact to jump to [1 - " + Contacts.Count + "]: ", "Type in a valid number", 1, Contacts.Count);
							contactIndex = contactToJumpTo - 1;
							break;

						// Had to make this ConsoleKey D for Mac
						case ConsoleKey.D:
						case ConsoleKey.Delete:	
							Console.WriteLine("WARNING! This action cannot be undone. Do you want to continue? Press Y/N");

							if (Console.ReadKey(true).Key == ConsoleKey.Y)
							{
								Contacts.RemoveAt(contactIndex);

								if (Contacts.Count == 0)
								{
									quit = true;
									Console.Clear();
									Console.WriteLine("There are no contacts.");
									Console.ReadKey(true);
								}

								if (contactIndex == Contacts.Count)
								{
									contactIndex--;
								}


							}
							break;

						case ConsoleKey.Q:
							quit = true;
							break;

					}

				} while (quit == false);

			}
			else
			{
				Console.WriteLine("There are no contacts in the contact list!");
				Console.ReadKey(true);

			}
		}

		public void ImportContacts()
		{
			Console.WriteLine("Inside Import Contacts..");
		}

		public void ExportContacts()
		{
			Console.WriteLine("Inside Export Contacts..");

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


		private int AskNumericQuestion(string question, string errorMessage, double lowerBound, double upperBound)
		{
			bool success;
			int result;

			do
			{
				Console.Clear();
				Console.Write(question);
				success = int.TryParse(Console.ReadLine(), out result);

				if (!success || result < lowerBound || result > upperBound)
				{
					Console.WriteLine(errorMessage);
					Console.ReadKey(true);
					success = false;
				}
			} while (!success);

			return result;
		}

	}
}
