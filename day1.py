
def main():
    input = [int(line.strip()) for line in open("day1.txt")]
    for i, item1 in enumerate(input):
        for j, item2 in enumerate(input):
            if i != j:
                if item1 + item2 == 2020:
                    print(item1 * item2)
                    return


if __name__ == '__main__':
    main()
