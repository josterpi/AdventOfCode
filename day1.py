
def main():
    input = [int(line.strip()) for line in open("input/day1.txt")]
    part1_solved = False
    for i, item1 in enumerate(input):
        for j, item2 in enumerate(input):
            if i != j:
                if item1 + item2 == 2020 and not part1_solved:
                    print("Part 1: %s\n" % (item1 * item2))
                    part1_solved = True
                for k, item3 in enumerate(input):
                    if j != k:
                        if item1 + item2 + item3 == 2020:
                            print("Part 2: %s\n" % (item1 * item2 * item3))
                            return


if __name__ == '__main__':
    main()
