import json

def has_space(s: str) -> bool:
    return len(s.split()) != 1

with open("./Utilities/gts.json", "r", encoding="utf8") as f:
    lines = f.readlines()

data = {"words": []}

def is_entry_in_meaning(entry, meaning):
    for keyword in meaning.lower().split():
        # print(entry[:3], keyword)
        if entry[:3] in keyword:
            return True
    return False

for line in lines:
    word_data = json.loads(line)
    entry: str = word_data["madde"]
    if has_space(entry):
        continue
    if not entry.isalpha():
        continue
    if len(entry) < 4 or 10 < len(entry):
        continue
    if "â" in entry:
        continue
    if entry[0].isupper():
        continue
    if entry.endswith("ma"):
        continue
    try:
        meaning = word_data["anlamlarListe"][0]["anlam"]
    except KeyError:
        continue
    if is_entry_in_meaning(entry, meaning):
        continue
    data["words"].append({
        "entry": entry,
        "meaning": meaning
    })

with open("./Utilities/words.json", "w", encoding="utf-8") as f:
    json.dump(data, f, ensure_ascii=False, indent=4)
