package controller;

import java.awt.BorderLayout;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.io.IOException;

import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JSplitPane;
import javax.swing.event.TreeSelectionEvent;
import javax.swing.event.TreeSelectionListener;

import view.FileContentView;
import view.FileTreeView;
import view.PathView;

public class MainController extends JFrame{

	private FileContentView fileContent; 
	private FileTreeView fileTree; 
	private PathView path; 
	private FileContentController fileContentController; 
	private PathController pathController;
	public MainController() throws IOException
	{
		this.fileContent = new FileContentView();
		this.fileTree = new FileTreeView();
		this.path = new PathView(); 
		this.fileContentController = new FileContentController(fileTree,fileContent,path);
		this.pathController = new PathController(fileTree, fileContent, path,fileContentController);
		
		JSplitPane mainPanel = new JSplitPane(JSplitPane.HORIZONTAL_SPLIT);
		mainPanel.setRightComponent(fileContent);
		mainPanel.setLeftComponent(fileTree);
		
		fileTree.tree.addTreeSelectionListener(new TreeSelectionListener() {
			
			@Override
			public void valueChanged(TreeSelectionEvent e) {
				setTitle(e.getPath().getLastPathComponent().toString());
			}
		});
		
		setLayout(new BorderLayout());
		add(path,BorderLayout.NORTH);
		add(mainPanel,BorderLayout.CENTER);
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		ImageIcon img = new ImageIcon("src/images/fileimage.png");
		setIconImage(img.getImage());
		setSize(800,600);
		setVisible(true);
	}
}
