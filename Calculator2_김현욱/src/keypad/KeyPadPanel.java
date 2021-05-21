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

	private JTextField calculatorDisplay;
	private JLabel showingProcess;
	private Constants constant;

	public KeyPadPanel(JLabel showingProcess, JTextField calculatorDisplay) {

		// 계산과정 화면 초기화
		this.calculatorDisplay = calculatorDisplay;
		this.showingProcess = showingProcess;

		// 숫자 패널 초기화
		this.keyPadPanel = new JPanel();

		// 계산과정 변수 초기화
		this.sum = 0.0;
		this.num = 0.0;
		this.temp = 0.0;
		this.isDone = true;
		this.isFirst = true;
		this.isFirstNumberButton = true;

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
		c = new JButton("C");
		ce = new JButton("CE");
		dot = new JButton(".");
		changingSign = new JButton("±");
		backSpace = new JButton("BACK");

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

		add(keyPadPanel);
		setLayout(new GridLayout());
	}

	// 두번째 숫자가 입력됐을 때 연산
	public void calculateWithNum(String operator) {
		if (operator == "＋") {
			sum += num;
		} else if (operator == "－") {
			sum += num;
		} else if (operator == "×") {
			sum *= num;
		} else if (operator == "÷") {
			sum /= num;
		}
	}

	// 숫자하나만 입력됐을 때 연산
	public void calculateWithNoNum(String operator) {
		if (operator == "＋") {
			sum += sum;
		} else if (operator == "－") {
			sum -= sum;
		} else if (operator == "×") {
			sum *= sum;
		} else if (operator == "÷") {
			sum /= sum;
		}
	}

	// 숫자버튼 이벤트리스너
	private class NumberButtonListene implements ActionListener {
		public void actionPerformed(ActionEvent e) {

			JButton btn = (JButton) e.getSource();
			String number = btn.getText();

			// 처음 입력하는 숫자인지 확인
			if (isFirstNumberButton) {
				calculatorDisplay.setText("");
				isFirstNumberButton = false;
			}

			// 숫자 입력
			calculatorDisplay.setText(calculatorDisplay.getText() + number);
			isDone = false;
			// 계산과정의 처음 숫자면 sum, 처음이아니면 num 에 저장
			if (isFirst) {
				sum = Double.valueOf(calculatorDisplay.getText());
			} else {
				num = Double.valueOf(calculatorDisplay.getText());
			}
		}
	}

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
			}

		}

		public void actOperator(String op) {
			if (!isDone) {
				calculateWithNum(operator);
				isDone = true;
			}
			operator = op;
			showingProcess.setText(sum.toString() + " " + operator);
			isFirst = false;
			isFirstNumberButton = true;
			// 앞선 연산자 적용
		}
	}
}
