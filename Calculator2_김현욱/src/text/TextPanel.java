package text;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.FlowLayout;
import java.awt.GridLayout;
import java.awt.event.*;

import javax.swing.*;

import keypad.KeyPadPanel;
import set.Constants;

public class TextPanel extends JPanel{
	
	// 가장 위에 있는 구성요소(기록버튼, 계산과정) 
	public JButton calculateRecordButton; 
	public JLabel showingProcess;
	public JPanel upperPanel;
	public JPanel buttonPanel;
	public JPanel textPanel;
	public JLabel kindLabel;
	
	// 입력창 
	public JTextField calculatorDisplay;
	public JPanel calculatorDisplayPanel; 
	
	// 계산기록 창
	public JTextArea calculatorRecord;
	public JButton deleteButton;
	public JPanel calculatorRecordPanel; 
	
	private Constants constants;
	
	public TextPanel()
	{
		this.constants = new Constants();

		this.showingProcess = new JLabel();
		showingProcess.setHorizontalAlignment(JLabel.RIGHT);
		this.calculateRecordButton = new JButton("기록");
		this.kindLabel = new JLabel("표준");
		kindLabel.setFont(constants.ButtonFont);
		this.upperPanel = new JPanel();
		this.buttonPanel = new JPanel();
		
		this.calculatorDisplay = new JTextField("0");
		calculatorDisplay.setHorizontalAlignment(JTextField.RIGHT);
		calculatorDisplay.setEditable(false);
		calculatorDisplay.setBorder(null);
		calculatorDisplay.setFont(constants.calculatorDisplayFont);
		
		this.calculatorDisplayPanel = new JPanel();
		this.textPanel = new JPanel();
	
		this.calculatorRecord = new JTextArea(50,20);
		calculatorRecord.setEditable(false);
		this.deleteButton = new JButton("삭제");
		deleteButton.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				calculatorRecord .setText("");
			}
		});
		this.calculatorRecordPanel = new JPanel(); 
		
		buttonPanel.setLayout(new BorderLayout());
		buttonPanel.add(calculateRecordButton,BorderLayout.EAST);
		buttonPanel.add(kindLabel, BorderLayout.WEST);
		upperPanel.add(buttonPanel);
		upperPanel.add(showingProcess);
		upperPanel.setLayout(constants.textGridLayout);
		
		calculatorDisplayPanel.add(calculatorDisplay);
		calculatorDisplayPanel.setLayout(new BorderLayout());
		
		textPanel.add(upperPanel);
		textPanel.add(calculatorDisplayPanel);
		textPanel.setLayout(constants.textGridLayout);
		
		calculatorRecordPanel.add(calculatorRecord);
		calculatorRecordPanel.add(deleteButton);
		
		calculatorDisplayPanel.setLayout(new GridLayout());
		calculateRecordButton.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e)
			{
				JFrame f = new JFrame();
				f.add(calculatorRecordPanel);
				f.setSize(500,500);
				f.setVisible(true);
			}
		}); 
		
		KeyPadPanel keyPadPanel = new KeyPadPanel(showingProcess,calculatorDisplay,calculatorRecord);
		
		add(textPanel);
		add(keyPadPanel);
		
		setLayout(constants.textGridLayout);	
		
		
	}
}
