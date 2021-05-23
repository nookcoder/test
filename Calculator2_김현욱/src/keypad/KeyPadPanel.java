package keypad;

import java.awt.*;
import java.awt.event.*;
import javax.swing.*;

import set.Constants;

public class KeyPadPanel extends JPanel {

	private JPanel keyPadPanel;

	// 숫자 패드에 들어갈 버튼들
	private JButton[] numberButton;
	private JButton ce;
	private JButton c;
	private JButton backSpace;
	private JButton divide;
	private JButton plus;
	private JButton equal;
	private JButton minus;
	private JButton multiply;
	private JButton dot;
	private JButton changingSign;

	// 계산과정에서 쓰일 변수
	private Double sum;
	private Double num;
	private Double temp;
	private String operator;
	private boolean isDone;
	private boolean isFirst;
	private boolean isFirstNumberButton;
	private boolean isFirstEqual;
	private boolean isEqualNext;
	private boolean isInfinity;

	private JTextField calculatorDisplay;
	private JLabel showingProcess;
	private JTextArea calculatorRecord;
	private Constants constant;

	public KeyPadPanel(JLabel showingProcess, JTextField calculatorDisplay, JTextArea calculatorRecord) {

		// 계산과정 화면 초기화
		this.calculatorDisplay = calculatorDisplay;
		this.showingProcess = showingProcess;
		this.calculatorRecord = calculatorRecord;
		// 숫자 패널 초기화
		this.keyPadPanel = new JPanel();

		// 계산과정 변수 초기화
		this.sum = 0.0;
		this.num = 0.0;
		this.temp = 0.0;
		this.isDone = true;
		this.isFirst = true;
		this.isFirstNumberButton = true;
		this.isFirstEqual = true;
		this.isEqualNext = false;
		this.isInfinity = false;

		this.constant = new Constants();

		// 버튼 초기화
		this.numberButton = new JButton[10];
		for (int number = 0; number < 10; number++) {
			numberButton[number] = new JButton(Integer.toString(number));
			constant.setButtonFont(numberButton[number]);
			numberButton[number].addActionListener(new NumberButtonListene());
		}
		this.plus = new JButton("＋");
		this.minus = new JButton("－");
		this.multiply = new JButton("×");
		this.divide = new JButton("÷");
		this.c = new JButton("C");
		this.ce = new JButton("CE");
		this.dot = new JButton(".");
		this.changingSign = new JButton("±");
		this.equal = new JButton("＝");
		this.backSpace = new JButton("BACK");

		// 연산자 이벤트 추가
		plus.addActionListener(new OperatorButton());
		minus.addActionListener(new OperatorButton());
		multiply.addActionListener(new OperatorButton());
		divide.addActionListener(new OperatorButton());
		equal.addActionListener(new OperatorButton());
		c.addActionListener(new ResetButton());
		ce.addActionListener(new ResetButton());
		dot.addActionListener(new DotListener());
		changingSign = new JButton("±");
		backSpace.addActionListener(new BackSpaceListener());

		// 버튼 꾸미기
		constant.setButtonFont(plus);
		constant.setButtonFont(minus);
		constant.setButtonFont(multiply);
		constant.setButtonFont(c);
		constant.setButtonFont(ce);
		constant.setButtonFont(dot);
		constant.setButtonFont(changingSign);
		constant.setButtonFont(equal);
		constant.setButtonFont(backSpace);
		constant.setButtonFont(divide);

		// 숫자 패널에 버튼 추가
		keyPadPanel.setLayout(new GridLayout(5, 4, 2, 2));

		keyPadPanel.add(ce);
		keyPadPanel.add(c);
		keyPadPanel.add(backSpace);
		keyPadPanel.add(divide);

		keyPadPanel.add(numberButton[7]);
		keyPadPanel.add(numberButton[8]);
		keyPadPanel.add(numberButton[9]);
		keyPadPanel.add(multiply);

		keyPadPanel.add(numberButton[4]);
		keyPadPanel.add(numberButton[5]);
		keyPadPanel.add(numberButton[6]);
		keyPadPanel.add(minus);

		keyPadPanel.add(numberButton[1]);
		keyPadPanel.add(numberButton[2]);
		keyPadPanel.add(numberButton[3]);
		keyPadPanel.add(plus);

		keyPadPanel.add(changingSign);
		keyPadPanel.add(numberButton[0]);
		keyPadPanel.add(dot);
		keyPadPanel.add(equal);
		calculatorDisplay.addKeyListener(new CalcKetListener());
		add(keyPadPanel);
		setLayout(new GridLayout());
	}

	// 두번째 숫자가 입력됐을 때 연산
	public void calculate(String operator, Double number) {
		if (operator == "＋") {
			sum += number;
		} else if (operator == "－") {
			sum -= number;
		} else if (operator == "×") {
			sum *= number;
		} else if (operator == "÷") {
			sum /= number;
		}
	}

	// 계산기 초기화 하기
	public void reset() {
		sum = 0.0;
		num = 0.0;
		temp = 0.0;
		isDone = true;
		isFirst = true;
		isFirstNumberButton = true;
		isFirstEqual = true;
		isEqualNext = false;
		operator = null;
		isInfinity = false;
		showingProcess.setText("");
		calculatorDisplay.setText("0");
	}

	// 계산기록 저장하기
	public void saveCalculatorRecord(String oldSum, String number) {
		if (operator != null) {
			calculatorRecord.append(oldSum + " " + operator + " " + number+ " = " + sum.toString() + "\n");
		}
	}

	// 등호(=) 작동 함수
	public void actEqual() {
		String oldSum = sum.toString();

		// 0으로 나눴을 때
		if (isInfinity) {
			reset();
			isDone = false;
			isInfinity = false;
			return;
		}

		// 연산자 다음의 등호일때
		if (isDone) {
			// 등호가 처음 입력됐을 때
			if (isFirstEqual) {
				temp = sum;
				isFirstEqual = false;
			}
			saveCalculatorRecord(makeIntPrinting(oldSum), makeIntPrinting(temp.toString()));
			calculate(operator, temp);
			showResult(oldSum, temp);
		}

		// 숫자 다음의 등호일때
		else {
			// 연산자가 입력 됐을 때
			if (operator != null) {
				calculate(operator, num);
				showResult(oldSum, num);
				saveCalculatorRecord(makeIntPrinting(oldSum), makeIntPrinting(num.toString()));
			}

			// 연산자가 없을 떄
			else {
				showingProcess.setText(oldSum + " =");
			}
		}
		isEqualNext = true;
	}

	// 게산기 로그 화면에 표시되게하는 함수
	public void showResult(String oldSum, Double number) {
		if (sum.toString() == "Infinity") {
			showingProcess.setText("");
			calculatorDisplay.setText("0으로 나눌 수 없습니다");
			isInfinity = true;
			return;
		} else if (sum.toString() == "NaN") {
			showingProcess.setText("");
			calculatorDisplay.setText("정의되지않은 결과입니다");
			isInfinity = true;
			return;
		}
		String newSum = makeIntPrinting(oldSum);
		String newNumber = makeIntPrinting(number.toString());
		String newResult = makeIntPrinting(sum.toString());
		showingProcess.setText(newSum + " " + operator + " " + newNumber + " =");
		calculatorDisplay.setText(newResult);
	}
	
	public String makeIntPrinting(String check) {
		String[] zeroCheck = check.split("\\.");
		String newString="0"; 
		int zeroCount = 0;
		
		for(int i =0; i<zeroCheck[1].length();i++)
		{
			if(zeroCheck[1].charAt(i) == '0')
			{
				zeroCount++; 
			}
		}
		
		if(zeroCheck[1].length() == zeroCount)
		{
			newString = zeroCheck[0];
		}
		else
		{
			newString = check;
		}
		
		return newString;
	}

	// 연산 기호 입력시 처리 함수
	public void actOperator(String op) {
		String oldSum = sum.toString();
		String newSum = makeIntPrinting(oldSum);
		// 앞선 연산자 적용
		if (!isDone && !isEqualNext) {
			calculate(operator, num);
			saveCalculatorRecord(newSum, makeIntPrinting(num.toString()));
			isDone = true;
		}

		operator = op;
		showingProcess.setText(makeIntPrinting(sum.toString()) + " " + operator);
		calculatorDisplay.setText(makeIntPrinting(sum.toString()));
		isFirst = false;
		isFirstNumberButton = true;
		isFirstEqual = true;
		isEqualNext = false;
	}

	// 백스페이스 로직
	public void actBackSpace() {
		if (!isEqualNext) {
			String oldText = calculatorDisplay.getText();
			String oldTextCheck = oldText.replaceAll("[,]", "");
			if(isFirstNumberButton)
			{
				return;
			}
			if(oldText.length() == 1) {
				calculatorDisplay.setText("0");
				getNumber();
				return;
			}
			String newText = oldText.substring(0, oldText.length() - 1);
			String newTextCheck = newText.replaceAll("[,]", "");
			if(newTextCheck.length() == 4 && newText.contains(","))
			{
				calculatorDisplay.setText(newTextCheck);
			}
			calculatorDisplay.setText(newText);
			getNumber();
		} 
		
		else {
			showingProcess.setText("");
		}
	}

	// 입력된 숫자 저장하기
	public void getNumber() {
		if (isFirst) {
			sum = Double.valueOf(calculatorDisplay.getText().replaceAll("[,]", ""));
		} else {
			num = Double.valueOf(calculatorDisplay.getText().replaceAll("[,]", ""));
		}
	}

	// 점 추가
	public void addDot() {
		String oldText = calculatorDisplay.getText();
		String newText = oldText + ".";
		if (!oldText.contains(".")) {
			if(isFirstNumberButton)
			{
				calculatorDisplay.setText("0.");
				return;
			}
			calculatorDisplay.setText(newText);
			isFirstNumberButton = false;
		}
	}

	// 숫자 길어지면 콤마 추가
	public String printingNumber(String number) {
		StringBuffer addComma = new StringBuffer();
		String newText;
		String oldText;
		String oldTextCheck;

		oldText = calculatorDisplay.getText() + number;
		oldTextCheck = oldText.replaceAll("[,]", "");
		if (oldTextCheck.length() <= 16) {
			addComma.append(oldText);
			if (oldTextCheck.length() != 1 && oldTextCheck.length() % 3 == 1 && !oldText.contains(".")) {
				addComma.insert(oldText.length() - 3, ",");
			}
			newText = addComma.toString();
		} else {
			newText = calculatorDisplay.getText();
		}
		return newText;
	}

	// 숫자버튼 이벤트리스너
	private class NumberButtonListene implements ActionListener {
		public void actionPerformed(ActionEvent e) {

			JButton btn = (JButton) e.getSource();
			String number = btn.getText();

			// 등호 다음 숫자 입력 시 계산기 초기화
			if (isEqualNext) {
				reset();
				isEqualNext = false;
			}

			// 처음 입력하는 숫자인지 확인
			if (isFirstNumberButton || calculatorDisplay.getText() == "0") {
				calculatorDisplay.setText("");
				isFirstNumberButton = false;
			}

			// 숫자 입력
			calculatorDisplay.setText(printingNumber(number));
			isDone = false;

			// 계산과정의 처음 숫자면 sum, 처음이아니면 num 에 저장
			getNumber();
		}
	}

	// 연산버튼 이벤트 리스너
	private class OperatorButton implements ActionListener {
		public void actionPerformed(ActionEvent e) {

			JButton btn = (JButton) e.getSource();
			String operatorBtn = btn.getText();

			if (operatorBtn == "＋") {
				actOperator("＋");
			} else if (operatorBtn == "－") {
				actOperator("－");
			} else if (operatorBtn == "×") {
				actOperator("×");
			} else if (operatorBtn == "÷") {
				actOperator("÷");
			} else if (operatorBtn == "＝") {
				actEqual();
			}

		}
	}

	// 초기화 버튼 이벤트 리스너( c, ce)
	private class ResetButton implements ActionListener {
		public void actionPerformed(ActionEvent e) {
			JButton btn = (JButton) e.getSource();
			String ResetBtn = btn.getText();

			if (ResetBtn == "C") {
				reset();
			}

			else if (ResetBtn == "CE") {
				calculatorDisplay.setText("0");
				if (isFirst) {
					sum = 0.0;
				} else {
					num = 0.0;
				}
				if (isEqualNext) {
					reset();
				}
			}
		}
	}

	// 백스페이스 이벤트
	private class BackSpaceListener implements ActionListener {
		public void actionPerformed(ActionEvent e) {
			actBackSpace();
		}
	}

	private class DotListener implements ActionListener {
		public void actionPerformed(ActionEvent e) {
			addDot();
		}
	}

	// 키보드 입력 이벤트
	private class CalcKetListener implements KeyListener {

		
		@Override
		public void keyTyped(KeyEvent e) {
			int operatorKeyCode = e.getKeyCode();
			calculatorDisplay.requestFocus();
			
			switch (operatorKeyCode) {
			case KeyEvent.VK_ADD:
				actOperator("＋");
				break;

			case KeyEvent.VK_MINUS:
				actOperator("－");
				break;

			case KeyEvent.VK_MULTIPLY:
				actOperator("×");
				break;

			case KeyEvent.VK_DIVIDE:
				actOperator("÷");
				break;

			case KeyEvent.VK_ENTER:
				actEqual();
				break;

			case KeyEvent.VK_EQUALS:
				actEqual();
				break;

			case KeyEvent.VK_ESCAPE:
				reset();
				break;

			case KeyEvent.VK_BACK_SPACE:
				actBackSpace();
				break;

			case KeyEvent.VK_PERIOD:
				addDot();
				break;
			}
		}

		@Override
		public void keyPressed(KeyEvent e) {
			calculatorDisplay.requestFocus();
		
			char number = e.getKeyChar();
			if (number >= '0' && number <= '9') {// 등호 다음 숫자 입력 시 계산기 초기화
				if (isEqualNext) {
					reset();
					isEqualNext = false;
				}

				// 처음 입력하는 숫자인지 확인
				if (isFirstNumberButton || calculatorDisplay.getText() == "0") {
					calculatorDisplay.setText("");
					isFirstNumberButton = false;
				}

				
				String oldText = calculatorDisplay.getText() + number;
				// 숫자 입력
				if (calculatorDisplay.getText().length() <= 16) {
					StringBuffer addCommaString = new StringBuffer();

					String oldTextCheck = oldText.replaceAll("[,]", "");
					if (oldTextCheck.length() != 1 && oldTextCheck.length() % 3 == 1 && !oldText.contains(".")) {
						addCommaString.append(oldText);
						addCommaString.insert(oldText.length() - 3, ",");
						calculatorDisplay.setText(addCommaString.toString());
					}

					else {
						calculatorDisplay.setText(calculatorDisplay.getText() + number);
					}
				}

				else {
					calculatorDisplay.setText(calculatorDisplay.getText());
				}

				isDone = false;

				// 계산과정의 처음 숫자면 sum, 처음이아니면 num 에 저장
				if (isFirst) {
					sum = Double.valueOf(calculatorDisplay.getText().replaceAll("[,]", ""));
				} else {
					num = Double.valueOf(calculatorDisplay.getText().replaceAll("[,]", ""));
				}
			} else {
				keyTyped(e);
			}
		}

		@Override
		public void keyReleased(KeyEvent e) {
			// TODO Auto-generated method stub

		}
	}
}
