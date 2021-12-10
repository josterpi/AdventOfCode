
def main():
    input = [line.strip() for line in open("input/day3.txt")]
    num_digits = range(len(input[0]))
    input_cols = []
    for i in num_digits:
        input_cols.append([int(x[i]) for x in input])
    gamma = []
    epsilon = []
    for col in input_cols:
        if sum(col) > len(col)/2:
            gamma.append('1')
            epsilon.append('0')
        else:
            gamma.append('0')
            epsilon.append('1')
    print("Part 1: %s" % (int(''.join(gamma), 2) * int(''.join(epsilon), 2)))


if __name__ == "__main__":
    main()
