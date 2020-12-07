
def main():
    input = [line.strip() for line in open("day3.txt")]
    width = len(input[0])
    x, y = (0, 0)
    trees = 0
    while y < len(input) - 1:
        x += 3
        y += 1
        if input[y][x % width] is '#':
            trees += 1
    print(f"Part 1: {trees}")

if __name__ == '__main__':
    main()
