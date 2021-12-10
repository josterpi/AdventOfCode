
def main():
    input = [line.strip() for line in open("input/day3.txt")]
    num_digits = len(input[0])
    input_cols = []
    for i in range(num_digits):
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

    # Part 2
    filtered_input = input.copy()
    for i in range(num_digits):
        digits = [int(x[i]) for x in filtered_input]
        filter = '0'
        if sum(digits) >= len(digits)/2:
            filter = '1'
        filtered_input = [x for x in filtered_input if x[i] == filter]
        if len(filtered_input) == 1:
            break
    print(filtered_input)


if __name__ == "__main__":
    main()
