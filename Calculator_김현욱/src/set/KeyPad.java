package set;

import java.awt.*;
import java.awt.event.*;

import javax.swing.*;

public class KeyPad extends JPanel {

	private JPanel keyPadPanel;
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
	
	private String lastedOperator; // ���� �ֱٿ� �Էµ� ��Ģ���� ��ȣ 
	private Double doubleNum;
	private Double doubleSum;
	private boolean isNewNumberStart; // ���ο� ���ڰ� �ԷµǴ� �� �Ǵ�
	private boolean isEqualNext; // = �� ���� �� ���� �̺�Ʈ���� �Ǵ�
	private boolean isFirstNumber; // ��� �������� ù��° �Է� �������� Ȯ�� 
	private boolean isOperatorNext; // ���� �ֱٿ� �Էµ� �� ���� ��ȣ���� Ȯ�� 
	
	private Constants constant;
	
	private JTextField textArea;
	private JLabel label;
	
	public KeyPad(JTextField textArea,JLabel label)
	{
		setLayout(new BorderLayout());
		this.keyPadPanel = new JPanel(); 
		this.numberButton = new JButton[10];
		this.textArea = textArea;
		this.label = label;
		
		// ���������� ���� ������ �ʱ�ȭ 
		this.doubleNum = 0.0;
		this.doubleSum = 0.0; 
		this.lastedOperator = null;
		this.isNewNumberStart = true;
		this.isFirstNumber = true;
		this.isEqualNext = false;
		this.isOperatorNext = false; 
	
		this.constant = new Constants();
		
		// ���� ��ư ���� 
		for(int number = 0; number<10;number++)
		{
			numberButton[number] = new JButton(Integer.toString(number));
			setButtonFont(numberButton[number]);
			numberButton[number].addActionListener(new NumberButtonListener());
		}
				
		this.plus = new JButton("+");
		this.minus = new JButton("��");
		this.multiply = new JButton("X");
		this.divide = new JButton("/");
		this.c = new JButton("C");
		this.ce = new JButton("CE");
		this.dot = new JButton(".");
		this.changingSign = new JButton("+/-");
		this.equal = new JButton("=");
		this.backSpace = new JButton("BACK");
		
		// �����ȣ ��ư Ŀ����
		setSignButtonFont(plus);
		setSignButtonFont(minus);
		setSignButtonFont(multiply);
		setSignButtonFont(c);
		setSignButtonFont(ce);
		setButtonFont(dot);
		setButtonFont(changingSign);
		setSignButtonFont(equal);
		setSignButtonFont(backSpace);
		setSignButtonFont(divide);
		
		// ���� ��ȣ �̺�Ʈ ó�� 
		plus.addActionListener(new OperatorListener());
		minus.addActionListener(new OperatorListener());
		multiply.addActionListener(new OperatorListener());
		divide.addActionListener(new OperatorListener());
		equal.addActionListener(new EqualListener());
		c.addActionListener(new ResetListener());
		ce.addActionListener(new ResetListener()); 
		dot.addActionListener(new DotListener());
		changingSign.addActionListener(new ChangingSignListener());
		backSpace.addActionListener(new BackSpaceListener());

		// �����е� �����
		keyPadPanel.setLayout(new GridLayout(5,4,2,2));
		
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
		
		add(keyPadPanel,BorderLayout.CENTER);
	}
	
	public void setButtonFont(JButton btn){
		btn.setFont(constant.font);
		btn.setBorderPainted(false);
		btn.setBackground(Color.WHITE);
	}
	
	public void setSignButtonFont(JButton btn) {
		btn.setFont(constant.signFont);
		btn.setBorderPainted(false);
		btn.setBackground(Color.LIGHT_GRAY);
	}
		
	public void runOperation(String operator){
		if(operator == "+") {doubleSum += doubleNum;}
		else if(operator == "��") {doubleSum -= doubleNum;}
		else if(operator == "X") {doubleSum *= doubleNum;}
		else if(operator == "/") {doubleSum /= doubleNum;}
	}
		
	public void setPrintingNumberToInt(Double number){
		String[] numberString = number.toString().split(".");
		if(numberString[1].equals("0")) {
			textArea.setText(numberString[0]);
		}
		else {
			textArea.setText(number.toString());
		}	
	}
		
	public void reset() {
		isNewNumberStart  = true; 
		isFirstNumber = true;
		isEqualNext = false;
		isOperatorNext = false;
		lastedOperator = null;
		
		doubleNum = 0.0;
		doubleSum = 0.0;
	}
		
		// ���� Ű �Է� �� �̺�Ʈ ó�� 
	private class NumberButtonListener implements ActionListener{
		
		public void actionPerformed(ActionEvent e){
			JButton numberButton = (JButton)e.getSource();
			String number = numberButton.getText();
			String result = textArea.getText(); 
			
			if(isEqualNext)
			{
				reset();
				textArea.setText(number);
			}
				
			// ���ο� ���� �Է½� ���� �������ִ� ���� ����� 
			if(isNewNumberStart ||result.equals("0")||isEqualNext)
			{
				textArea.setText("");
				textArea.setText(number);
			}					
			// �������� ���� �Է� �� 
			else {textArea.setText(result + number);}
			
				getNumber();
				
				// ���� ��ȣ ���� ������ �� ó��(������ִ� ����) 
				isOperatorNext = false;
				isNewNumberStart = false;
				isEqualNext = false;
			}
			
			public void getNumber() {
				// �Է��� ���� ���� 
				if(isFirstNumber) {doubleSum = Double.valueOf(textArea.getText());}
				else{ doubleNum = Double.valueOf(textArea.getText());}
			}
		}
		
		// ���� ��ȣ �̺�Ʈ ó�� 
	private class OperatorListener implements ActionListener{
			public void actionPerformed(ActionEvent e ) {
				
				JButton operatorButton = (JButton)e.getSource();
				String operator = operatorButton.getText();
				
				if(lastedOperator  != null && !isEqualNext) {runOperation(lastedOperator);}
				
				lastedOperator = operator;	
				
				label.setText(doubleSum.toString());
				label.setText(operator);
				
				isOperatorNext = true;
				isNewNumberStart  = true;
				isEqualNext = false;
				isFirstNumber = false;
			}		
		}
		
		// ��ȣ(=) �̺�Ʈ ó�� 
	private class EqualListener implements ActionListener{
			public void actionPerformed(ActionEvent e)
			{
				if(!isOperatorNext)
				{
					isEqualNext = true;
					runOperation(lastedOperator);
					String doubleSumString = Double.toString(doubleSum);
					String doubleSumCheck = doubleSumString.substring(doubleSumString.length() - 1);
					
					if(doubleSumCheck.equals("0"))
					{
						textArea.setText(doubleSum.toString().substring(0, doubleSumString.length()-2));
					}
					
					else
					{
						textArea.setText(doubleSum.toString());
					}
				}
			}
		}
		
		// c ce �Է½� �̺�Ʈ ó�� 
		private class ResetListener implements ActionListener{
			
			public void actionPerformed(ActionEvent e)
			{
				JButton resetButton = (JButton)e.getSource();
				
				// ���� �ʱ�ȭ 
				if(resetButton.getText() == "C")
				{
					textArea.setText("0");
					reset();
				}
				
				// ��ȣ ���� ce �Է� �� �ʱ�ȭ, �������� ce�Է½� ���ڸ� �ʱ�ȭ 
				else if (resetButton.getText() == "CE")
				{
					textArea.setText("0");
					if(isEqualNext) {
						reset();
					}
				}
			}
		}

		// +/- �Է� �̺�Ʈ ó�� 
		private class ChangingSignListener implements ActionListener{
			
			public void actionPerformed(ActionEvent e)
			{ 
				// ���⿡�� ��ó������ �Է��� �� 
				if(isNewNumberStart)
				{
					textArea.setText("");
					textArea.setText("-");
					isNewNumberStart = false;
					if(!textArea.getText().equals("-")) { doubleSum = Double.valueOf(textArea.getText());}
					return;
				}
				
				if(isFirstNumber) 
				{
					showChangeOperatorWithDouble(doubleSum);
					doubleSum = Double.valueOf(textArea.getText());
				}
				else
				{
					showChangeOperatorWithDouble(doubleNum);
					doubleNum = Double.valueOf(textArea.getText());
				}
			}
			
			// ��ȣ �ٲ�� �� ����ڿ��� �����ִ� �Լ� (�Ǽ�)
			public void showChangeOperatorWithDouble(Double number) {
				
				if(number > 0)
				{
					textArea.setText("");
					textArea.setText("-" + number.toString());
				}
				
				else if(number < 0)
				{
					textArea.setText("");
					textArea.setText(number.toString());
				}
			}
		}
		
		// . �Է� �̺�Ʈ ó�� 
	private class DotListener implements ActionListener{
		
		public void actionPerformed(ActionEvent e) {
			String oldString = textArea.getText();
			String newString = oldString + ".";
			
			if(!textArea.getText().contains(".")) {textArea.setText(newString);}
		}

	}

	// �齺���̽� �̺�Ʈ ó�� 
	private class BackSpaceListener implements ActionListener{
		public void actionPerformed(ActionEvent e) {
			String originalText = textArea.getText();
			
			if(originalText.length() != 0) {
				String backText = originalText.substring(0,originalText.length()-1);
				textArea.setText(backText);
				
				if(isFirstNumber) {doubleSum = Double.valueOf(textArea.getText());}
				else{ doubleNum = Double.valueOf(textArea.getText());}
			}
				
			else { 
				textArea.setText("0");
			}
	}	
			
	public class NumberButtonMouseListener implements MouseListener{
			
		public void mouseEntered(MouseEvent e) {
			JButton btn = (JButton)e.getSource();
			btn.setBackground(Color.LIGHT_GRAY);
		}
			
		public void mouseExited(MouseEvent e) {
			JButton btn = (JButton)e.getSource();
			btn.setBackground(Color.white);
		}

		@Override
		public void mouseClicked(MouseEvent e) {
			// TODO Auto-generated method stub
			
		}

		@Override
		public void mousePressed(MouseEvent e) {
			// TODO Auto-generated method stub
			
		}

			@Override
			public void mouseReleased(MouseEvent e) {
				// TODO Auto-generated method stub
				
			}
		}
		
		private class OperatorButtonMouseListener implements MouseListener{

			@Override
			public void mouseClicked(MouseEvent e) {
				// TODO Auto-generated method stub
				
			}

			@Override
			public void mousePressed(MouseEvent e) {
				// TODO Auto-generated method stub
				
			}

			@Override
			public void mouseReleased(MouseEvent e) {
				// TODO Auto-generated method stub
				
			}

			@Override
			public void mouseEntered(MouseEvent e) {
				JButton btn = (JButton)e.getSource();
				btn.setBackground(Color.WHITE);
				
			}

			@Override
			public void mouseExited(MouseEvent e) {
				JButton btn = (JButton)e.getSource();
				btn.setBackground(Color.LIGHT_GRAY);
				
			}
		}	
	}
}
