
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
    def filter_rating(input, filter_func):
        filtered_input = input.copy()
        for i in range(num_digits):
            digits = [int(x[i]) for x in filtered_input]
            filter = filter_func(digits)
            filtered_input = [x for x in filtered_input if x[i] == filter]
            if len(filtered_input) == 1:
                return filtered_input[0]

    def oxygen_filter(digits):
        if sum(digits) >= len(digits)/2:
            return '1'
        return '0'

    def cotwo_filter(digits):
        if sum(digits) >= len(digits)/2:
            return '0'
        return '1'

    oxygen_rating = int(filter_rating(input, oxygen_filter), 2)
    cotwo_rating = int(filter_rating(input, cotwo_filter), 2)
    print(f"Part 2: {oxygen_rating*cotwo_rating}")


if __name__ == "__main__":
    main()
