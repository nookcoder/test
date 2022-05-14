package keypad;

import java.awt.*;
import java.awt.event.*;

import javax.swing.*;

import set.Constants;

public class KeyPadPanel extends JPanel {

	private JPanel keyPadPanel;

	// ���� �е忡 �� ��ư��
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

	// ���������� ���� ����
	private Double sum;
	private Double num;
	private Double temp;
	private String operator;
	private String oldNegateString;
	private boolean isDone;
	private boolean isFirst;
	private boolean isFirstNumberButton;
	private boolean isFirstEqual;
	private boolean isEqualNext;
	private boolean isInfinity;
	private boolean isHaveNegate;
	private boolean isCENext;
	
	private JLabel negateLabel; 
	private JTextField calculatorDisplay;
	private JLabel showingProcess;
	private JTextArea calculatorRecord;
	private Constants constant;

	public KeyPadPanel(JLabel showingProcess, JTextField calculatorDisplay, JTextArea calculatorRecord) {

		// ������ ȭ�� �ʱ�ȭ
		this.calculatorDisplay = calculatorDisplay;
		this.showingProcess = showingProcess;
		this.calculatorRecord = calculatorRecord;
		// ���� �г� �ʱ�ȭ
		this.keyPadPanel = new JPanel();
		this.negateLabel = new JLabel(); 
		negateLabel.setVisible(true);
		
		// ������ ���� �ʱ�ȭ
		this.sum = 0.0;
		this.num = 0.0;
		this.temp = 0.0;
		this.isDone = true;
		this.isFirst = true;
		this.isFirstNumberButton = true;
		this.isFirstEqual = true;
		this.isEqualNext = false;
		this.isInfinity = false;
		this.isHaveNegate = false;
		this.isCENext = false;
		
		this.constant = new Constants();

		// ��ư �ʱ�ȭ
		this.numberButton = new JButton[10];
		for (int number = 0; number < 10; number++) {
			numberButton[number] = new JButton(Integer.toString(number));
			constant.setButtonFont(numberButton[number]);
			numberButton[number].addActionListener(new NumberButtonListene());
		}
		this.plus = new JButton("+");
		this.minus = new JButton("-");
		this.multiply = new JButton("*");
		this.divide = new JButton("/");
		this.c = new JButton("C");
		this.ce = new JButton("CE");
		this.dot = new JButton(".");
		this.changingSign = new JButton("+/-");
		this.equal = new JButton("=");
		this.backSpace = new JButton("<");

		// ������ �̺�Ʈ �߰�
		plus.addActionListener(new OperatorButton());
		minus.addActionListener(new OperatorButton());
		multiply.addActionListener(new OperatorButton());
		divide.addActionListener(new OperatorButton());
		equal.addActionListener(new OperatorButton());
		c.addActionListener(new ResetButton());
		ce.addActionListener(new ResetButton());
		dot.addActionListener(new DotListener());
		changingSign.addActionListener(new NegateListener());
		backSpace.addActionListener(new BackSpaceListener());

		// ��ư �ٹ̱�
		constant.setOperatorButton(plus);
		constant.setOperatorButton(minus);
		constant.setOperatorButton(multiply);
		constant.setOperatorButton(c);
		constant.setOperatorButton(ce);
		constant.setButtonFont(dot);
		constant.setButtonFont(changingSign);
		constant.setEqualButton(equal);
		constant.setOperatorButton(backSpace);
		constant.setOperatorButton(divide);

		// ���� �гο� ��ư �߰�
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
	
	public String setOverflow(String check)
	{
		if(check.contains("E"))
		{
			String[] overflowCheck = check.split("E");
			String overflowResultString;
			if(Integer.parseInt(overflowCheck[1]) >= 7 && Integer.parseInt(overflowCheck[1]) <= 15)
			{
				overflowResultString = overflowCheck[0].replaceAll("[.]", "");
				overflowResultString = overflowResultString.substring(0,overflowResultString.length());
				overflowResultString = setComma(overflowResultString);
			}
			
			else
			{
				overflowResultString = overflowCheck[0].substring(0, overflowCheck[0].length())+"e+"+overflowCheck[1];
				if(Integer.parseInt(overflowCheck[1]) < 0)
				{
					overflowResultString =  overflowCheck[0].substring(0, overflowCheck[0].length())+"e"+overflowCheck[1];
				}
				if(overflowResultString.equals("1.0e+16"))
				{
					overflowResultString = setComma("9999999999999999");
				}
			}
			return overflowResultString;
		}
		
		
		return check;
	}
	
	public String setComma(String number) {
		if(!number.contains("."))
		{
			StringBuffer numberBuffer = new StringBuffer();
			String noCommaNumber = number.replaceAll("[,]", "");
			noCommaNumber.replaceAll("-", "");
			numberBuffer.append(noCommaNumber);
			switch(noCommaNumber.length()) {
				case 1 : case 2: case 3:
					noCommaNumber.replaceAll("[,]", "");
					break;
					
				case 4: case 5: case 6:
					numberBuffer.insert(noCommaNumber.length() - 3, ",");
					break;
				case 7: case 8: case 9:
					numberBuffer.insert(noCommaNumber.length() - 3,",");
					numberBuffer.insert(noCommaNumber.length() - 6,",");
					break;
				case 10: case 11: case 12:
					numberBuffer.insert(noCommaNumber.length() - 3,",");
					numberBuffer.insert(noCommaNumber.length() - 6,",");
					numberBuffer.insert(noCommaNumber.length() - 9, ",");
					break;
				case 13: case 14: case 15:	
					numberBuffer.insert(noCommaNumber.length() - 3,",");
					numberBuffer.insert(noCommaNumber.length() - 6,",");
					numberBuffer.insert(noCommaNumber.length() - 9, ",");
					numberBuffer.insert(noCommaNumber.length() -12, ",");
					break;
				case 16: 
					numberBuffer.insert(noCommaNumber.length() -3,",");
					numberBuffer.insert(noCommaNumber.length() -6,",");
					numberBuffer.insert(noCommaNumber.length() -9, ",");
					numberBuffer.insert(noCommaNumber.length() -12, ",");
					numberBuffer.insert(noCommaNumber.length() -15, ",");
					break;
			}
			return numberBuffer.toString();
		}
		return number;
	}
	
	// ���� ������� �޸� �߰�
	public String printingNumber(String number) {
		String newText;
		String oldText;
		String oldTextCheck;

		oldText = calculatorDisplay.getText() + number;
		oldTextCheck = oldText.replaceAll("[,]", "");
		if (oldTextCheck.length() <= 16) {
			newText = setComma(oldText);
		} else {
			newText = calculatorDisplay.getText();
		}
		return newText;
	}
	
	public void resizeNumber() {
		switch(calculatorDisplay.getText().replaceAll("[,]","").length())
		{
		case 1: case 2: case 3: case 4: case 5: case 6: case 7: case 8: case 9: case 10:
				calculatorDisplay.setFont(constant.calculatorDisplayFont);
				break;
			case 11:
				calculatorDisplay.setFont(constant.calculatorDisplayFont2);
				break;
			case 12:
				calculatorDisplay.setFont(constant.calculatorDisplayFont3);
				break;
			case 13:
				calculatorDisplay.setFont(constant.calculatorDisplayFont4);
				break;
			case 14:
				calculatorDisplay.setFont(constant.calculatorDisplayFont5);
				break;
			case 15:
				calculatorDisplay.setFont(constant.calculatorDisplayFont6);
				break;
			case 16: case 17: case 18: case 19: case 20: case 21: case 22: case 23:
				calculatorDisplay.setFont(constant.calculatorDisplayFont7);
				break;
				
		}
	}
	
	// �Էµ� ���� �����ϱ�
	public void getNumber() {
		if (isFirst) {
			sum = Double.valueOf(calculatorDisplay.getText().replaceAll("[,]", ""));
		} else {
			num = Double.valueOf(calculatorDisplay.getText().replaceAll("[,]", ""));
		}
	}

	// �ι�° ���ڰ� �Էµ��� �� ����
	public void calculate(String operator, Double number) {
		if (operator == "+") {
			sum += number;
		} else if (operator == "-") {
			sum -= number;
		} else if (operator == "*") {
			sum *= number;
		} else if (operator == "/") {
			sum /= number;
		}
	}

	// ���� �ʱ�ȭ �ϱ�
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
		isHaveNegate = false;
		isCENext = false;
		showingProcess.setText("");
		calculatorDisplay.setText("0");
		calculatorDisplay.setFont(constant.calculatorDisplayFont);
	}

	
	// ����� �����ϱ�
	public void saveCalculatorRecord(String oldSum, String number) {
		if (operator != null) {
			calculatorRecord.append(setOverflow(oldSum) + " " + operator + " " + setOverflow(number)+ " = " + setOverflow(sum.toString()) + "\n");
		}
	}

	// �Ի�� �α� ȭ�鿡 ǥ�õǰ��ϴ� �Լ�
	public void showResult(String oldSum, String number) {
		if (sum.toString() == "Infinity") {
			calculatorDisplay.setText("정의되지 않은 결과입니다.");
			isInfinity = true;
			return;
		} else if (sum.toString() == "NaN") {
			showingProcess.setText("");
			calculatorDisplay.setText("0으로 나눌 수 없습니다.");
			isInfinity = true;
			return;
		}
		String newSum = makeIntPrinting(oldSum);
		String newNumber = makeIntPrinting(number);
		String newResult = makeIntPrinting(sum.toString());
		showingProcess.setText(setOverflow(newSum) + " " + operator + " " + setOverflow(newNumber) + " =");
		calculatorDisplay.setText(setOverflow(setComma(newResult)));
		resizeNumber();
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
	
	public void printingInCalculatorWithNoEqual(String check,String temp1) {
		if(check.toString() == "Infinity")
		{
			isFirst = true;
			isFirstNumberButton = true;
			isFirstEqual = true;
			isDone = false;
			isEqualNext = false;
			showingProcess.setText(temp1 + " �� 0 " + operator);
			calculatorDisplay.setText("0���� ���� �� �����ϴ�");
			sum = 0.0;
			num = 0.0;
			temp = 0.0;
			isInfinity = true;
			return;
		}
		
		String newCheckString = makeIntPrinting(check.toString());
		
		showingProcess.setText(setOverflow(newCheckString) + " " + operator);
		calculatorDisplay.setText(setOverflow(setComma(newCheckString)));
		resizeNumber();
	}
	
	// ���� ce ��ư
	public void actCE()
	{
		calculatorDisplay.setText("0");
		isCENext = true;
		if (isFirst) {
			sum = 0.0; 
			getNumber();
		} else {
			num = 0.0;
			getNumber();
		}
		if (isEqualNext) {
			reset();
		}
	}
	
	// ��ȣ(=) �۵� �Լ�
	public void actEqual() {
		String oldSum = sum.toString();
		// 0���� ������ ��
		if (isInfinity) {
			reset();
			isDone = false;
			isInfinity = false;
			return;
		}

		// ������ ������ ��ȣ�϶�
		if (isDone) {
			// ��ȣ�� ó�� �Էµ��� ��
			if(isCENext)
			{
				isCENext = false;
				temp = 0.0;
				isFirstEqual = false;
			}
			else if (isFirstEqual) {
				temp = sum;
				isFirstEqual = false;
			}
			saveCalculatorRecord(setOverflow(makeIntPrinting(oldSum)), setOverflow(makeIntPrinting(temp.toString())));
			calculate(operator, temp);
			showResult(oldSum, temp.toString());
		}

		// ���� ������ ��ȣ�϶�
		else {
			// �����ڰ� �Է� ���� ��
			if (operator != null) {
				calculate(operator, num);
				showResult(oldSum, num.toString());
				saveCalculatorRecord(makeIntPrinting(oldSum), makeIntPrinting(num.toString()));
			}

			// �����ڰ� ���� ��
			else {
				showingProcess.setText(setOverflow(makeIntPrinting(oldSum)) + " =");
			}
		}
		isEqualNext = true;
		resizeNumber();
	}
	
	// ���� ��ȣ �Է½� ó�� �Լ�
	public void actOperator(String op) {
		String oldSum = sum.toString();
		String newSum = makeIntPrinting(oldSum);
		// �ռ� ������ ����
		// 0���� ������ ��
		if (isInfinity) {
			reset();
			isDone = false;
			isInfinity = false;
			return;
		}
		
		if (!isDone && !isEqualNext) {
			isDone = true;
			calculate(operator, num);
			saveCalculatorRecord(newSum, makeIntPrinting(num.toString()));
		}
		operator = op;
		printingInCalculatorWithNoEqual(setComma(sum.toString()),setComma(oldSum));
		isFirst = false;
		isFirstNumberButton = true;
		isFirstEqual = true;
		isEqualNext = false;
	}

	// �齺���̽� ����
	public void actBackSpace() {
		if (!isEqualNext) {
			String oldText = calculatorDisplay.getText().replaceAll("[,]", "");
			String removeOldText = oldText.substring(0, oldText.length()-1);
			if(isFirstNumberButton)
			{
				return;
			}
			if(oldText.length() == 1 || (oldText.length() == 2 && oldText.contains("-"))) {
				calculatorDisplay.setText("0");
				getNumber();
				return;
			}
			String newText = setComma(removeOldText);
			calculatorDisplay.setText(newText);
			getNumber();
		} 
		
		else {
			showingProcess.setText("");
		}
		resizeNumber();
	}
	
	public void actNegate() {
		String oldSum = sum.toString();
		String newSum = makeIntPrinting(oldSum);

		if(isEqualNext)
		{
			if(showingProcess.getText().contains("negate"))
			{
				showingProcess.setText("negate("+oldNegateString +")" );
				oldNegateString = "negate("+oldNegateString +")";
				sum *= -1;
				calculatorDisplay.setText(setOverflow(setComma(makeIntPrinting(sum.toString()))));
				return;	
			}
			isHaveNegate = true;
			sum = sum * -1; 
			calculatorDisplay.setText(setOverflow(setComma(makeIntPrinting(sum.toString()))));
			showingProcess.setText("negate("+newSum+")" );
			oldNegateString = "negate("+newSum+")";
			return;
		}

		if(isDone && !calculatorDisplay.getText().equals("0"))
		{
			isDone = false; 
			isHaveNegate = true;
			num = sum * -1; 
			calculatorDisplay.setText(setOverflow(setComma(makeIntPrinting(num.toString()))));
			showingProcess.setText(newSum +" "+ operator + " "+ "negate("+newSum+")" );
			oldNegateString = "negate("+newSum+")";
			return;
		}

		
		if(showingProcess.getText().contains("negate"))
		{
			showingProcess.setText(newSum +" "+ operator + " "+ "negate("+oldNegateString +")" );
			oldNegateString = "negate("+oldNegateString +")";
			num *= -1;
			calculatorDisplay.setText(setOverflow(setComma(makeIntPrinting(num.toString()))));
			return;
		}
		
		if(isFirst && !calculatorDisplay.getText().equals("0"))
		{
			sum *= -1 ;
			calculatorDisplay.setText(setOverflow(setComma(makeIntPrinting(sum.toString()))));
			return; 
		}
		
		if(!calculatorDisplay.getText().equals("0"))
		{
			num *= -1;
			calculatorDisplay.setText(setOverflow(setComma(makeIntPrinting(num.toString()))));
		}
		resizeNumber();
	}
	
	// �� �߰�
	public void addDot() {
		String oldText = calculatorDisplay.getText();
		String newText = oldText + ".";
		if (!oldText.contains(".")) {
			if(isFirstNumberButton)
			{
				calculatorDisplay.setText("0.");
				isDone = false;
				isFirstNumberButton = false;
				return;
			}
			calculatorDisplay.setText(newText);
			isFirstNumberButton = false;
		}
		resizeNumber();
	}
	
	// ���ڹ�ư �̺�Ʈ������
	private class NumberButtonListene implements ActionListener {
		public void actionPerformed(ActionEvent e) {

			JButton btn = (JButton) e.getSource();
			String number = btn.getText();

			if (isInfinity) {
				reset();
				isDone = false;
				isInfinity = false;
				return;
			}
			
			// ��ȣ ���� ���� �Է� �� ���� �ʱ�ȭ
			if (isEqualNext || (isEqualNext && isHaveNegate)) {
				reset();
				isEqualNext = false;
			}

			if(number.equals("0") && calculatorDisplay.getText().equals("0"))
			{
				isDone = false;
				getNumber();
				return;
			}
			
			// ó�� �Է��ϴ� �������� Ȯ��
			if (isFirstNumberButton || calculatorDisplay.getText().equals("0") )
			{
				calculatorDisplay.setText("");
			}
			
			// ���� �Է�
			isFirstNumberButton = false;
			calculatorDisplay.setText(printingNumber(number));
			isDone = false;
			// �������� ó�� ���ڸ� sum, ó���̾ƴϸ� num �� ����
			getNumber();
			resizeNumber();
			calculatorDisplay.requestFocusInWindow();
		}
	}

	// �����ư �̺�Ʈ ������
	private class OperatorButton implements ActionListener {
		public void actionPerformed(ActionEvent e) {

			JButton btn = (JButton) e.getSource();
			String operatorBtn = btn.getText();

			if (operatorBtn == "+") {
				actOperator("+");
			} else if (operatorBtn == "-") {
				actOperator("-");
			} else if (operatorBtn == "*") {
				actOperator("*");
			} else if (operatorBtn == "/") {
				actOperator("/");
			} else if (operatorBtn == "=") {
				actEqual();
			}
			calculatorDisplay.requestFocusInWindow();
		}
	}

	// �ʱ�ȭ ��ư �̺�Ʈ ������( c, ce)
	private class ResetButton implements ActionListener {
		public void actionPerformed(ActionEvent e) {
			JButton btn = (JButton) e.getSource();
			String ResetBtn = btn.getText();

			if (ResetBtn == "C") {
				reset();
			}

			else if (ResetBtn == "CE") {
				actCE();
			}
			calculatorDisplay.requestFocusInWindow();
		}
	}

	// �齺���̽� �̺�Ʈ
	private class BackSpaceListener implements ActionListener {
		public void actionPerformed(ActionEvent e) {
			actBackSpace();
			calculatorDisplay.requestFocusInWindow();
		}
	}

	private class DotListener implements ActionListener {
		public void actionPerformed(ActionEvent e) {
			addDot();
			calculatorDisplay.requestFocusInWindow();
		}
	}

	private class NegateListener implements ActionListener{
		public void actionPerformed(ActionEvent e) {
			actNegate();
			calculatorDisplay.requestFocusInWindow();
		}
	}
	
	// Ű���� �Է� �̺�Ʈ
	private class CalcKetListener implements KeyListener {

		@Override
		public void keyTyped(KeyEvent e) {
			int operatorKeyCode = e.getKeyCode();
			calculatorDisplay.requestFocus();

			if(e.isShiftDown())
			{
				switch(operatorKeyCode)
				{
					case KeyEvent.VK_EQUALS:
						actOperator("=");
						break;
					case KeyEvent.VK_8:
						actOperator("*");
						break;
				}
				return;
			}
			
			switch (operatorKeyCode) {
			case KeyEvent.VK_ADD:
				actOperator("+");
				break;

			case KeyEvent.VK_MINUS:
				actOperator("-");
				break;

			case KeyEvent.VK_MULTIPLY:
				actOperator("*");
				break;

			case KeyEvent.VK_DIVIDE: case KeyEvent.VK_SLASH:
				actOperator("/");
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
				
			case KeyEvent.VK_DELETE:
				actCE();
				break;
				
			case KeyEvent.VK_BACK_SPACE:
				actBackSpace();
				break;

			case KeyEvent.VK_PERIOD:
				addDot();
				break;
				
			case KeyEvent.VK_F9:
				actNegate();
				break;
			}
		}

		@Override
		public void keyPressed(KeyEvent e) {
			calculatorDisplay.requestFocus();
			
			char number = e.getKeyChar();
			if (number >= '0' && number <= '9') {// ��ȣ ���� ���� �Է� �� ���� �ʱ�ȭ
				
				if (isInfinity) {
					reset();
					isDone = false;
					isInfinity = false;
					return;
				}
				
				if (isEqualNext) {
					reset();
					isEqualNext = false;
				}

				if(number == '0' && calculatorDisplay.getText().equals("0"))
				{
					isDone = false;
					getNumber();
					return;
				}
				
				// ó�� �Է��ϴ� �������� Ȯ��
				if (isFirstNumberButton || calculatorDisplay.getText().equals("0")) {
					calculatorDisplay.setText("");
					isFirstNumberButton = false;
				}

				
				String oldText = calculatorDisplay.getText() + number;
				// ���� �Է�
				if (calculatorDisplay.getText().replaceAll("[,]","").length() < 16) {
					String oldTextCheck = oldText.replaceAll("[,]", "");
						calculatorDisplay.setText(setComma(oldTextCheck));
				}

				else {
					calculatorDisplay.setText(calculatorDisplay.getText());
				}

				isDone = false;
				resizeNumber();
				// �������� ó�� ���ڸ� sum, ó���̾ƴϸ� num �� ����
				if (isFirst) {
					sum = Double.valueOf(calculatorDisplay.getText().replaceAll("[,]", ""));
				} else {
					num = Double.valueOf(calculatorDisplay.getText().replaceAll("[,]", ""));
				}
			}
			
			else {
				keyTyped(e);
			}
			
			
		}

		@Override
		public void keyReleased(KeyEvent e) {
			// TODO Auto-generated method stub
		}
	}
}
