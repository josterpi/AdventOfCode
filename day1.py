
def main():
    input = [int(line.strip()) for line in open("input/day1.txt")]
    count = 0
    for a, b in zip(input[:-1], input[1:]):
        if b > a:
            count += 1
    print(f"Part 1: {count}")

    # Part 2
    count2 = 0
    for i in range(len(input) - 2):
        if sum(input[i+1:i+4]) > sum(input[i:i+3]):
            count2 += 1
    print(f"Part 2: {count2}")


if __name__ == '__main__':
    main()
