
# .* bags contain no other bags.
# .* bags contain \d .* bag[s]?.
# .* bags contain \d .* bag[s]?, \d .* bag[s]?, ... .

def parse_input(filename):
    rules = {}
    with open(filename) as f:
        for line in f:
            bag, spec = line.strip(".\n").split(" bags contain ")
            bag_rules =  []
            if spec != "no other bags":
                for part in spec.split(", "):
                    part = part.split()[:-1]
                    count = int(part[0])
                    name = " ".join(part[1:])
                    bag_rules.append({'count': count, 'name': name})
            rules[bag] = bag_rules
    return rules

def find_gold(bag, rules):
    if not rules:
        return False
    bag_names = [b['name'] for b in rules[bag]]
    if "shiny gold" in bag_names:
        return True
    return any([find_gold(name, rules) for name in bag_names if rules[name]])

def main():
    input = parse_input("day7.txt")
    gold_count = 0
    for key in input.keys():
        if find_gold(key, input):
            gold_count += 1
    print(f"Part 1: {gold_count}")

if __name__ == '__main__':
    main()