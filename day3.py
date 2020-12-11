
def check_slope(input, slope):
    width = len(input[0])
    x, y = (0, 0)
    trees = 0
    while y < len(input) - 1:
        x += slope[0]
        y += slope[1]
        if input[y][x % width] is '#':
            trees += 1
    return trees

def main():
    input = [line.strip() for line in open("input/day3.txt")]
    trees = check_slope(input, (3, 1))
    print(f"Part 1: {trees}")
    slopes = [(1, 1), (3, 1), (5, 1), (7, 1), (1, 2)]
    part2 = 1
    for s in slopes:
        part2 *= check_slope(input, s)
    print(f"Part 2: {part2}")

if __name__ == '__main__':
    main()
