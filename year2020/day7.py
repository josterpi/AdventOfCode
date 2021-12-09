
def parse_input(filename):
    rules = {}
    with open(filename) as f:
        for line in f:
            bag, spec = line.strip(".\n").split(" bags contain ")
            bag_rules =  {}
            if spec != "no other bags":
                for part in spec.split(", "):
                    part = part.split()[:-1]
                    count = int(part[0])
                    name = " ".join(part[1:])
                    bag_rules[name] =  count
            rules[bag] = bag_rules
    return rules

def find_gold(bag, rules):
    if not rules:
        return False
    bag_names = rules[bag].keys()
    if "shiny gold" in bag_names:
        return True
    return any([find_gold(name, rules) for name in bag_names])

def fill_gold(bag, rules):
    if not rules[bag]:
        return 0
    return sum([count + fill_gold(name, rules) * count for name, count in rules[bag].items()])

def main():
    input = parse_input("input/day7.txt")
    gold_count = 0
    for key in input.keys():
        if find_gold(key, input):
            gold_count += 1
    print(f"Part 1: {gold_count}")
    print("Part 2: %s" % fill_gold("shiny gold", input))

if __name__ == '__main__':
    main()
