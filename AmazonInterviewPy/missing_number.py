find_missing([3, 7, 1, 2, 8, 4, 5]) # missing = 6

def find_missing(input):
    input_len = len(input)
    max = input_len + 2
    target_sum = 0
    actual_sum = 0

    for cnt in range(1, max):
        target_sum += cnt
        index = cnt - 1

        if (index < input_len):
            actual_sum += input[index]

    return target_sum - actual_sum
