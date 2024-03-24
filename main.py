import firebase_admin
from firebase_admin import credentials
from firebase_admin import firestore

# Initialize Firebase
cred = credentials.Certificate("serviceAccountKey.json")
firebase_admin.initialize_app(cred)
db = firestore.client()

def take_lsas_test():
    print("Welcome to the Liebowitz Social Anxiety Scale (LSAS) test.")
    print("Please rate each situation according to your level of anxiety and avoidance.")
    print("Anxiety levels:")
    print("0 = none")
    print("1 = mild")
    print("2 = moderate")
    print("3 = severe")
    print("Avoidance levels:")
    print("0 = never")
    print("1 = occasionally")
    print("2 = often")
    print("3 = severe")

    lsas_questions = [
        "Using a telephone in public",
        "Participating in a small group activity",
        "Eating in public",
        "Talking to a person in authority",
        "Being observed while working",
        "Meeting people you don't know",
        "Speaking during a meeting",
        "Making eye contact with people you don't know well",
        "Giving a speech"
        # Add more questions as needed
    ]

    total_score = 0
    for question in lsas_questions:
        print(f"\nHow anxious or fearful are you in the situation: {question}?")
        anxiety_level = int(input("Enter your anxiety level (0-3): "))
        print(f"How often do you avoid the situation: {question}?")
        avoidance_level = int(input("Enter your avoidance level (0-3): "))
        total_score += anxiety_level + avoidance_level

    return total_score

def save_results_to_firebase(score):
    # Assuming 'lsas_results' is the collection name in Firebase
    doc_ref = db.collection('lsas_results').document()
    doc_ref.set({
        'score': score
    })
    print("Results saved to Firebase successfully!")

def main():
    score = take_lsas_test()
    save_results_to_firebase(score)

if __name__ == "__main__":
    main()