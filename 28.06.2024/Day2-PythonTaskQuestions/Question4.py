import random

def generate_secret_number():
    return "1234"

def count_cows(secret, guess):
    cows = 0
    for i in range(len(secret)):
        if secret[i] == guess[i]:
            cows += 1
    return cows

def count_bulls(secret, guess):
    bulls = 0
    for i in range(len(guess)):
        if guess[i] in secret and guess[i] != secret[i]:
            bulls += 1
    return bulls

def count_cows_and_bulls(secret, guess):
    cows = count_cows(secret,guess)
    bulls = count_bulls(secret,guess)
    return cows, bulls

def play_game():

    secret_number = generate_secret_number()
    attempts = 0
    score = 0

    print("Welcome to the Cow and Bull Game!")
    print("Try to guess the 4-digit number.")
    print("For each correct digit in the correct place, you get a cow.")
    print("For each correct digit in the wrong place, you get a bull.")

    while True:
        guess = input("\nEnter your guess (4-digit number): ")
        
        if not guess.isdigit() or len(guess) != 4:
            print("Please enter a 4-digit number.")
            continue
        
        attempts += 1

        # Count cows and bulls
        cows, bulls = count_cows_and_bulls(secret_number, guess)

        # Check if guess is correct
        if cows == 4:
            print(f"Congratulations! You guessed the number {secret_number} correctly in {attempts} attempts.")
            score += 1
            break
        else:
            print(f"Your guess {guess} has {cows} cows and {bulls} bulls.")

    print(f"\nYour score: {score}")

# Main function to start the game
if __name__ == "__main__":
    play_game()
