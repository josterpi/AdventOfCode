
def main():
    with open("day6.txt") as f:
        input = [x for x in f.read().split("\n\n")]
    total = sum(len(set(list(x.replace('\n', '')))) for x in input)
    print(f"Part 1: {total}")
    total2 = 0
    for group in input:
        answers = [set(list(x)) for x in group.split()]
        total2 += len(set.intersection(*answers))
    print(f"Part 2: {total2}")


if __name__ == '__main__':
    main()
