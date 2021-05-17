package main;

import java.awt.BorderLayout;
import java.awt.Component;
import java.awt.Container;
import java.awt.FlowLayout;
import java.awt.Font;
import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.*;

public class SettingCalculatorDisplay extends JPanel
{
	private JPanel displayPanel;
	private JPanel keyPadPanel;
	
	private JTextField textArea; 
	
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
	
	private Constants constant;
	
	private EventListener eventListener;
	
	public String lastedOperator;
	private int num1, num2;
	private int sum;
	public boolean isStart = true; 
	public boolean isContinue = false;
	public boolean isEqualNext = false;
	
	public SettingCalculatorDisplay() {
		this.constant = new Constants();
		this.eventListener = new EventListener();
		this.num1 = 0; 
		this.num2 = 0; 
		this.sum = 0;
		
		this.displayPanel = new JPanel(); 
		this.keyPadPanel = new JPanel();
		
		displayPanel.setLayout(new FlowLayout());
		keyPadPanel.setLayout(new GridLayout(0,4,5,5));
		
		this.textArea = new JTextField(11);
		textArea.setText("0"); 
		textArea.setHorizontalAlignment(JTextField.RIGHT);
		textArea.setFont(constant.font);
		
		add(textArea,BorderLayout.NORTH);
		
		this.keyPadPanel = new JPanel(); 
		this.numberButton = new JButton[10];
		
		for(int number = 0; number<10;number++)
		{
			numberButton[number] = new JButton(Integer.toString(number));
			setButtonFont(numberButton[number]);
			
			numberButton[number].addActionListener(new ActionListener() {
			
				// 계산기 버튼 클릭 시 입력되게 하는 함수 
				public void actionPerformed(ActionEvent e) {
					JButton numberButton = (JButton)e.getSource();
					String number = numberButton.getText();
					String result = textArea.getText(); 
					if(isStart||result.equals("0"))
					{
						textArea.setText("");
						textArea.setText(number);
					}			
					
					else if(isContinue)
					{
						textArea.setText("");
					}
					
					else {textArea.setText(result + number);}
					
					isStart = false;
				}
			});
		}
		
		this.plus = new JButton("+");
		plus.addActionListener(new ActionListener() {
			
			public void actionPerformed(ActionEvent e ) {
				
				JButton operatorButton = (JButton)e.getSource();
				String operator = operatorButton.getText();
				if(operator == "+")
				{
					if(isEqualNext)
					{
						textArea.setText("");
					}
					
					else
					{
						num1 = Integer.parseInt(textArea.getText());
						num2 = Integer.parseInt(textArea.getText());
						sum += num1;
						num1 = 0;
						lastedOperator = "+";
						isStart = true;
					}
					
				}
						
			}
			
		});
		this.minus = new JButton("ㅡ");
		this.multiply = new JButton("X");
		this.divide = new JButton("%");
		this.c = new JButton("C");
		this.ce = new JButton("CE");
		this.dot = new JButton(".");
		this.changingSign = new JButton("+/-");
		this.equal = new JButton("=");
		equal.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e)
			{
				JButton operatorButton = (JButton)e.getSource();
				String operator = operatorButton.getText();
				if(operator == "=") {
					if(lastedOperator == "+")
					{
						if(isEqualNext)
						{
							num2 = Integer.parseInt(textArea.getText());
							sum += num2;
							isEqualNext = true;
						}
						
						else 
						{
							sum += num2;
							isEqualNext = true;
						}
					}
					textArea.setText(Integer.toString(sum));
				}
			}
		});
		
		this.backSpace = new JButton("BACK");
		
		setSignButtonFont(plus);
		setSignButtonFont(minus);
		setSignButtonFont(multiply);
		setSignButtonFont(c);
		setSignButtonFont(ce);
		setSignButtonFont(dot);
		setSignButtonFont(changingSign);
		setSignButtonFont(equal);
		setSignButtonFont(backSpace);

		minus.addActionListener(null);
		multiply.addActionListener(null);
		divide.addActionListener(null);
		c.addActionListener(null);
		ce.addActionListener(null);
		dot.addActionListener(null);
		changingSign.addActionListener(null);
		equal.addActionListener(null);
		backSpace.addActionListener(null);

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
		
		keyPadPanel.setLayout(new GridLayout(5,4));
		
		add(keyPadPanel,BorderLayout.CENTER);
		
	}
	
	public void setButtonFont(JButton btn) {
		btn.setFont(constant.font);
	}
	
	public void setSignButtonFont(JButton btn) {
		btn.setFont(constant.signFont);
	}
}
