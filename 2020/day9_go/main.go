package main

import (
	"fmt"
	"strconv"
	"os"
	"log"
	"bufio"
)

type dataInput []string

func main() {
	lines, err := readLines("data.txt")
	checkError(err)

	for i := 25; i < len(lines); i++ {
		currentNumber, forErr := strconv.ParseInt(lines[i], 10, 64)
		checkError(forErr)

		subSlice := lines[i - 25:i]

		doesContain := false

		for _, line := range lines {
			parsedInt, parseErr := strconv.ParseInt(line, 10, 64)
			checkError(parseErr)

			partner := currentNumber - parsedInt

			if(subSlice.contains(strconv.FormatInt(partner, 10))) {
				doesContain = true
				break
			} else {
				continue
			}
		}

		if !doesContain {
			fmt.Printf("The number is %d", currentNumber)
		}
	}
}

func readLines(path string) (dataInput, error) {
	file, err := os.Open(path)
	checkError(err)
	defer file.Close()

	var lines dataInput
	scanner := bufio.NewScanner(file)
	for scanner.Scan() {
		lines = append(lines, scanner.Text())
	}
	return lines, scanner.Err()
}

func (input dataInput) contains(valueToCheck string) bool {
	for _, val := range input {
		if val == valueToCheck {
			return true
		}
	}
	return false
}

func checkError(err error) {
	if err != nil {
		log.Fatalf("errorCheck: %s", err)
		panic(err)
	}
}