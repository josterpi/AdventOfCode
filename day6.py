
def main():
    with open("day6.txt") as f:
        input = [x for x in f.read().split("\n\n")]
    total = sum(len(set(list(x.replace('\n', '')))) for x in input)
    print(f"Part 1: {total}")


if __name__ == '__main__':
    main()
