const display = document.querySelector(".calculator-input");
const keys = document.querySelector(".calculator-keys");

let displayValue = "0";
let operator = null;
let firstValue = null;
let waitingSecondValue = false;

function updateDisplay() {
    display.value = displayValue;
}

keys.addEventListener("click", function (e) {
    const element = e.target;
    const value = element.value;
    switch (value) {
        case "+":
        case "-":
        case "*":
        case "/":
        case "=":
            handleOperator(value);
            break;
        case ".":
            inputDecimal();
            break;
        case "clear":
            clearDisplay();
            break;
        case undefined:
            break;
        default:
            inputNumber(value);
            break;
    }

    updateDisplay();
})

function handleOperator(nextOperator) {
    let value = parseFloat(displayValue);
    if (operator && waitingSecondValue) {
        operator = nextOperator;
        return;
    }
    if (firstValue == null) {
        firstValue = value;
    }
    else {
        const result = calculate(firstValue, operator, value);
        if(Number.isInteger(result)){
            displayValue=result.toString();
        }else{

            displayValue = result.toPrecision(10).toString();
        }
        firstValue = result;
    }
    waitingSecondValue = true;
    operator = nextOperator;
}
function calculate(firstNumber, op, secondNumber) {
    switch (op) {
        case "+":
            return firstNumber + secondNumber;
        case "-":
            return firstNumber - secondNumber;
        case "*":
            return firstNumber * secondNumber;
        case "/":
            return firstNumber / secondNumber;
        default:
            return secondNumber;
    }
}

function inputNumber(num) {
    if (waitingSecondValue) {
        displayValue = num;
        waitingSecondValue = false;
    }
    else {
        displayValue = displayValue == "0" ? num : displayValue + num;
    }
}

function inputDecimal() {
    if (!displayValue.includes(".")) {
        displayValue += ".";
    }
}

function clearDisplay() {
    displayValue = "0";
}
updateDisplay();

//ÖDEV:
//1. Klavyeden girilen rakamlar da çalışsın
//2. Ondalık basamak her zaman görülmesin