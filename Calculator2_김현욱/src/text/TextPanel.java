package text;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.ComponentOrientation;
import java.awt.Dimension;
import java.awt.FlowLayout;
import java.awt.GridLayout;
import java.awt.Image;
import java.awt.event.*;

import javax.swing.*;
import javax.swing.plaf.basic.BasicScrollBarUI;

import keypad.KeyPadPanel;
import set.Constants;

public class TextPanel extends JPanel{
	
	// 가장 위에 있는 구성요소(기록버튼, 계산과정) 
	public JButton calculateRecordButton; 
	public JLabel showingProcess;
	public JPanel upperPanel;
	public JPanel recordButtonPanel;
	public JPanel deleteButtonPanel;
	public JPanel textPanel;
	public JLabel kindLabel;
	public JPanel miniPanel = new JPanel();
	// 입력창 
	public JTextField calculatorDisplay;
	public JPanel calculatorDisplayPanel; 
	
	// 계산기록 창
	public JTextArea calculatorRecord;
	public JButton deleteButton;
	public JPanel calculatorRecordPanel; 
	public JScrollPane calculatorRecordScroll;
	
	public JPanel bottomPanel;
	public KeyPadPanel keyPadPanel;
	public JLabel label = new JLabel("기록"); 
	private JPanel labelPanel = new JPanel(); 
	
	private Constants constants;
	
	public TextPanel()
	{
		this.constants = new Constants();
		
		this.showingProcess = new JLabel();
		showingProcess.setHorizontalAlignment(JLabel.RIGHT);
		this.calculateRecordButton = new JButton(new ImageIcon("src/images/record.png"));
		calculateRecordButton.setBorderPainted(false);
		calculateRecordButton.setContentAreaFilled(false);
		this.kindLabel = new JLabel("표준");
		kindLabel.setFont(constants.RECORD_FONT);
		this.upperPanel = new JPanel();
		this.recordButtonPanel = new JPanel();
		
		this.calculatorDisplay = new JTextField("0");
		calculatorDisplay.requestFocusInWindow();
		calculatorDisplay.setHorizontalAlignment(JTextField.RIGHT);
		calculatorDisplay.setEditable(false);
		calculatorDisplay.setBorder(null);
		calculatorDisplay.setFont(constants.calculatorDisplayFont);
		
		this.calculatorDisplayPanel = new JPanel();
		this.textPanel = new JPanel();
	
		this.calculatorRecord = new JTextArea();
		calculatorRecord.setEditable(false);
		calculatorRecord.setBackground(constants.RECORD_BACKGROUND);
		this.calculatorRecordScroll = new JScrollPane(calculatorRecord);
		calculatorRecordScroll.setHorizontalScrollBarPolicy(ScrollPaneConstants.HORIZONTAL_SCROLLBAR_AS_NEEDED );
		calculatorRecordScroll.setBorder(null);
		calculatorRecordScroll.getVerticalScrollBar().setUI(new BasicScrollBarUI() {
			@Override
			protected void configureScrollBarColors() {
				this.trackColor = constants.RECORD_BACKGROUND;
				this.thumbColor = Color.GRAY;
			}
		});
		calculateRecordButton.addActionListener(new ChangingPad());
		
		this.deleteButtonPanel = new JPanel();
		this.deleteButton = new JButton(constants.DELETE_IMAGE);
		deleteButton.setBorderPainted(false);
		deleteButton.setContentAreaFilled(false);
		deleteButton.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				calculatorRecord .setText("");
			}
		});
		deleteButtonPanel.setLayout(new BorderLayout());
		deleteButtonPanel.setBackground(constants.RECORD_BACKGROUND);
		deleteButtonPanel.add(deleteButton,BorderLayout.EAST);
		
		this.calculatorRecordPanel = new JPanel(); 
		this.bottomPanel = new JPanel();
		
		recordButtonPanel.setLayout(new BorderLayout());
		recordButtonPanel.add(calculateRecordButton,BorderLayout.EAST);
		recordButtonPanel.add(kindLabel, BorderLayout.WEST);
		upperPanel.add(recordButtonPanel);
		upperPanel.add(showingProcess);
		upperPanel.setLayout(constants.textGridLayout);
		
		calculatorDisplayPanel.add(calculatorDisplay);
		calculatorDisplayPanel.setLayout(new BorderLayout());
		
		textPanel.add(upperPanel);
		textPanel.add(calculatorDisplayPanel);
		textPanel.setLayout(constants.textGridLayout);
		
		calculatorRecordPanel.setLayout(new BorderLayout());
		calculatorRecordPanel.add(calculatorRecordScroll,BorderLayout.CENTER);
		calculatorRecordPanel.add(deleteButtonPanel,BorderLayout.SOUTH);
		
		calculatorDisplayPanel.setLayout(new GridLayout());
	
		keyPadPanel = new KeyPadPanel(showingProcess,calculatorDisplay,calculatorRecord);
		
		label.setFont(constants.RECORD_FONT);
		labelPanel.setLayout(new BorderLayout());
		labelPanel.add(label,BorderLayout.WEST);
		labelPanel.setBackground(constants.RECORD_BACKGROUND);
		
		miniPanel.add(textPanel);
		bottomPanel.setLayout(new BorderLayout());
		bottomPanel.add(keyPadPanel,BorderLayout.CENTER);
		miniPanel.add(bottomPanel);
		miniPanel.setLayout(constants.textGridLayout);
		add(miniPanel);
		setLayout(constants.textGridLayout);		
		addComponentListener(new SizeListener());
	}
	
	private class ChangingPad implements ActionListener{

		private String state = "keyPad"; 

		@Override
		public void actionPerformed(ActionEvent e) {
			// TODO Auto-generated method stub
			if(state.equals("keyPad"))
			{
				bottomPanel.removeAll();
				bottomPanel.add(calculatorRecordPanel,BorderLayout.CENTER);
				bottomPanel.updateUI();
				bottomPanel.repaint();
				state = "recordPad";
			}
			else if(state.equals("recordPad")) {

				bottomPanel.removeAll();
				bottomPanel.add(keyPadPanel,BorderLayout.CENTER);
				bottomPanel.updateUI();
				bottomPanel.repaint();
				state = "keyPad";
			}
		}
	}
	
	private class SizeListener implements ComponentListener{
		@Override
		public void componentResized(ComponentEvent e) {
			// TODO Auto-generated method stub
			if(e.getComponent().getWidth() > 900)
			{
				resetMiniPanel();
				calculatorRecordPanel.removeAll();
				calculatorRecordPanel.add(calculatorRecordScroll,BorderLayout.CENTER);
				calculatorRecordPanel.add(deleteButtonPanel,BorderLayout.SOUTH);
				calculatorRecordPanel.add(labelPanel,BorderLayout.NORTH);
				calculatorRecordPanel.updateUI();
				calculatorRecordPanel.repaint();
				calculateRecordButton.setVisible(false);
				add(calculatorRecordPanel);
				setLayout(new GridLayout(1,0));
				updateUI();
				repaint();
			}
			else if(e.getComponent().getWidth() <= 900) {
				resetMiniPanel();
				calculateRecordButton.setVisible(true);
				calculatorRecordPanel.removeAll();
				calculatorRecordPanel.add(calculatorRecordScroll,BorderLayout.CENTER);
				calculatorRecordPanel.add(deleteButtonPanel,BorderLayout.SOUTH);
				calculatorRecordPanel.updateUI();
				calculatorRecordPanel.repaint();
				updateUI();
				repaint();}
		}

		@Override
		public void componentMoved(ComponentEvent e) {
			// TODO Auto-generated method stub
			
		}

		@Override
		public void componentShown(ComponentEvent e) {
			// TODO Auto-generated method stub
			
		}

		@Override
		public void componentHidden(ComponentEvent e) {
			// TODO Auto-generated method stub
			
		}
		
		public void resetMiniPanel() {
			removeAll();
			miniPanel.removeAll();
			bottomPanel.removeAll();
			bottomPanel.add(keyPadPanel,BorderLayout.CENTER);
			bottomPanel.updateUI();
			bottomPanel.repaint();
			miniPanel.add(textPanel);
			miniPanel.add(bottomPanel);
			miniPanel.setLayout(constants.textGridLayout);
			miniPanel.updateUI();
			miniPanel.repaint();
			add(miniPanel);
		}
	}
}


