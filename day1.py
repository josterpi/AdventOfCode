
def main():
    input = [int(line.strip()) for line in open("input/day1.txt")]
    count = 0
    for a, b in zip(input[:-1], input[1:]):
        if b > a:
            count += 1
    print(f"Part 1: {count}")


if __name__ == '__main__':
    main()
