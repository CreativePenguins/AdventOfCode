package main

import (
	"fmt"
	"bufio"
	"log"
	"os"
	"sort"
	"strconv"
)

type stringDataInput []string
type intSlice []int

func main() {
	lines, err := readLinesToInt("data.txt")
	checkError(err)

	sort.Slice(lines,
		func(i, j int) bool { return lines[i] < lines[j] })

	currentJoule := 0

	oneJouleDiff := 0
	twoJouleDiff := 0
	threeJouleDiff := 1

	for _, value := range lines {
		difference := value - currentJoule
		switch difference {
		case 1:
			oneJouleDiff++
		case 2:
			twoJouleDiff++;
		case 3:
			threeJouleDiff++
		}

		currentJoule = value
	}

	fmt.Printf("One: %d, Two: %d, Three: %d\nMult: %d", oneJouleDiff, twoJouleDiff, threeJouleDiff, oneJouleDiff * threeJouleDiff)
}

func readLinesToString(path string) (stringDataInput, error) {
	file, err := os.Open(path)
	checkError(err)
	defer file.Close()

	var lines stringDataInput
	scanner := bufio.NewScanner(file)
	for scanner.Scan() {
		lines = append(lines, scanner.Text())
	}
	return lines, scanner.Err()
}

func readLinesToInt(path string) (intSlice, error) {
	file, err := os.Open(path)
	checkError(err)
	defer file.Close()

	var lines intSlice
	scanner := bufio.NewScanner(file)
	for scanner.Scan() {
		newInt, parseErr := strconv.Atoi(scanner.Text())
		checkError(parseErr)

		lines = append(lines, newInt)
	}
	return lines, scanner.Err()
}

func (input stringDataInput) contains(valueToCheck string) bool {
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

func (slice intSlice) sum() int {
	var total int
	for _, value := range slice {
		total += value
	}
	return total
}
