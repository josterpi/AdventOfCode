
def main():
    input = [line.strip().split() for line in open("input/day2.txt")]
    x, y = 0, 0
    y2, aim = 0, 0
    for direction, units in input:
        units = int(units)
        if direction == "forward":
            x += units
            y2 += units * aim
        if direction == "up":
            y -= units
            aim -= units
        if direction == "down":
            y += units
            aim += units
    print(f"Part 1: {x*y}")
    print(f"Part 2: {x*y2}")


if __name__ == "__main__":
    main()
