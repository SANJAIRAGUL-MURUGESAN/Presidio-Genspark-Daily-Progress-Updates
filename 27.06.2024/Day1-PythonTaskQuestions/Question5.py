def is_valid_name(name):
  return name.isalpha() or name.isspace() or "'" in name

def is_valid_age(age):
  try:
    return int(age) >= 0
  except ValueError:
    return False

def is_valid_date_of_birth(date_of_birth):
  """Checks if the date of birth is in YYYY-MM-DD format (basic validation)."""
  if len(date_of_birth) != 10 or date_of_birth.count("-") != 2:
    return False
  try:
    year, month, day = map(int, date_of_birth.split("-"))
    return 1 <= month <= 12 and 1 <= day <= 31
  except ValueError:
    return False

def is_valid_phone_number(phone_number):
  """Checks if the phone number consists of digits, hyphens, spaces, and parentheses (basic validation)."""
  return all(char in "0123456789 -() " for char in phone_number)

def get_valid_input(prompt, validator):
  while True:
    user_input = input(prompt)
    if validator(user_input):
      return user_input
    else:
      print("Invalid input. Please try again.")

name = get_valid_input("Enter your name: ", is_valid_name)
age = int(get_valid_input("Enter your age: ", is_valid_age))
date_of_birth = get_valid_input("Enter your date of birth (YYYY-MM-DD): ", is_valid_date_of_birth)
phone_number = get_valid_input("Enter your phone number: ", is_valid_phone_number)

# Print details in a formatted way
print("\n**Personal Details**")
print(f"Name: {name}")
print(f"Age: {age}")
print(f"Date of Birth: {date_of_birth}")
print(f"Phone Number: {phone_number}")
