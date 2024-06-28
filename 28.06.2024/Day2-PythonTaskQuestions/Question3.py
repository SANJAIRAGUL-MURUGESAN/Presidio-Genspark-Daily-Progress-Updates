players = [
    {"name": "Player1", "score": 120},
    {"name": "Player2", "score": 95},
    {"name": "Player3", "score": 150},
    {"name": "Player4", "score": 80},
    {"name": "Player5", "score": 110},
    {"name": "Player6", "score": 135},
    {"name": "Player7", "score": 100},
    {"name": "Player8", "score": 115},
    {"name": "Player9", "score": 90},
    {"name": "Player10", "score": 125},
    {"name": "Player12", "score": 105},
    {"name": "Player13", "score": 10}
]

# Sort players by score in descending order, reverse=true for descending order
sorted_players = sorted(players, key=lambda x: x['score'], reverse=True)

# Print the top 10 players
print("Top 10 Players:")
for i, player in enumerate(sorted_players[:10]):
    print(f"{i+1}. {player['name']}: {player['score']}")
