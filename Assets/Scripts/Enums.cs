public enum EventLocation {
    JobAgency,
    TheCrypt,
    Downtown
}

public enum EventActivity {
    GainCurrency, // To be renamed later
    GainRelationship, // To be renamed later
}

public enum EventTimeslot {
    None,
    Morning,
    Night,
}

public struct ChoiceData {
    public string choiceText;
    public int choiceIndex;

    public ChoiceData(string text, int index) {
        choiceText = text;
        choiceIndex = index;
    }
}