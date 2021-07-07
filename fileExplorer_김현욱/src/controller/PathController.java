package controller;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.File;
import java.io.IOException;
import java.nio.file.Files;

import javax.swing.JButton;
import javax.swing.event.TreeSelectionEvent;
import javax.swing.event.TreeSelectionListener;
import javax.swing.tree.DefaultMutableTreeNode;
import javax.swing.tree.TreePath;

import images.ImageSource;
import model.Setting;
import view.FileContentView;
import view.FileTreeView;
import view.PathView;

public class PathController {

	private FileTreeView treeView; 
	private FileContentView contentView; 
	private PathView pathView; 
	private FileContentController contentController;
	
	public PathController(FileTreeView treeView,FileContentView contentView,PathView pathView,FileContentController contentController)
	{
		this.treeView = treeView;
		this.contentView = contentView; 
		this.pathView = pathView;
		this.contentController = contentController;
		
		// 파일트리 선택 시 경로 표시 
		treeView.tree.addTreeSelectionListener(new TreeSelectionListener() {
			
			@Override
			public void valueChanged(TreeSelectionEvent e) {
				String currentPath = getPath(e);
				pathView.pathField.setText(currentPath);
			}
			
			private String getPath(TreeSelectionEvent event) {
				StringBuffer path = new StringBuffer();
				TreePath treePath = event.getPath();
				Object[] list = treePath.getPath();
				for (int index = 1; index < list.length; index++) {
					path.append(((DefaultMutableTreeNode) list[index]).getUserObject() + "\\");
				}
				return path.toString();
			}
		});
		
		// 뒤로가기 버튼 이벤트리스너
		pathView.backButton.addActionListener(new ActionListener() {
			
			@Override
			public void actionPerformed(ActionEvent e) {
				if(contentController.backLog.empty())
				{
					return;
				}

				contentController.forwardLog.push(contentController.backLog.peek());
				contentController.backLog.pop();
				contentController.addIcon(contentController.backLog.peek());
				try {
					pathView.pathField.setText(contentController.backLog.peek().getCanonicalPath());
				} catch (IOException e1) {
					e1.printStackTrace();
				}
			}
		});
		
		// 앞으로 가기 
		pathView.forwardButton.addActionListener(new ActionListener() {
			
			@Override
			public void actionPerformed(ActionEvent e) {
				if(contentController.forwardLog.empty())
				{
					return;
				}
				contentController.addIcon(contentController.forwardLog.peek());
				contentController.backLog.push(contentController.forwardLog.peek());
				try {
					pathView.pathField.setText(contentController.forwardLog.peek().getCanonicalPath());
				} catch (IOException e1) {
					e1.printStackTrace();
				}
				contentController.forwardLog.pop();
			}
		});
		
		pathView.searchField.addActionListener(new ActionListener() {
			
			@Override
			public void actionPerformed(ActionEvent e) {
				contentView.iconPanel.removeAll();
				File file = new File(pathView.pathField.getText());
				contentController.findFile(file);
				contentView.iconPanel.revalidate();
				contentView.iconPanel.repaint();
				contentView.iconPanel.updateUI();
			}
		});
		
	}
}
