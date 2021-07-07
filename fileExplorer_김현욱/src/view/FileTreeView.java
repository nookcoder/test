package view;

import java.awt.BorderLayout;
import java.awt.Image;
import java.io.File;
import java.io.IOException;
import java.nio.file.Files;

import javax.swing.ImageIcon;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.JTree;
import javax.swing.event.TreeExpansionEvent;
import javax.swing.event.TreeWillExpandListener;
import javax.swing.tree.DefaultMutableTreeNode;
import javax.swing.tree.DefaultTreeCellRenderer;
import javax.swing.tree.ExpandVetoException;
import javax.swing.tree.TreePath;

import images.ImageSource;

public class FileTreeView extends JPanel implements TreeWillExpandListener {
	public JTree tree;
	public JScrollPane treeScroll;
	private ImageSource imgSource;
	// public DefaultMutableTreeNode node;

	public FileTreeView() throws IOException {
		this.imgSource = new ImageSource();
		
		File file = new File("C:"+File.separator);
		
		DefaultMutableTreeNode root = new DefaultMutableTreeNode("내 PC");
		DefaultMutableTreeNode localRoot = new DefaultMutableTreeNode(file);
		root.add(localRoot);

		tree = new JTree(root);
		tree.addTreeWillExpandListener(this);
		addChild(file, localRoot);
		tree.putClientProperty("JTree.lineStyle", "None");
		tree.setCellRenderer(setTreeIcon());
		treeScroll = new JScrollPane(tree);
		setLayout(new BorderLayout());

		add(treeScroll, BorderLayout.CENTER);
	}
	
	// 트리 폴더이미지 설정 
	public DefaultTreeCellRenderer setTreeIcon()
	{
		ImageIcon folderImageTemp = imgSource.folderImageTemp;
		Image folderImage = folderImageTemp.getImage().getScaledInstance(20, 20, Image.SCALE_SMOOTH);
		DefaultTreeCellRenderer renderer = new DefaultTreeCellRenderer();
		renderer.setLeafIcon(new ImageIcon(folderImage));
		renderer.setClosedIcon(new ImageIcon(folderImage));
		renderer.setOpenIcon(new ImageIcon(folderImage));

		return renderer;
	}

	// 파잃 트리 노드 추가 함수
	public void addChild(File file, DefaultMutableTreeNode parent) {
		File[] files = file.listFiles();

		// 파일이 비어있으면 중지
		if (files == null) {
			return;
		}

		// 노드 추가
		for (File directory : files) {
			if (directory.isDirectory() && !directory.isHidden() && Files.isReadable(directory.toPath())) {
				parent.add(new DefaultMutableTreeNode(directory.getName()));
			}
		}
	}

	// 경로 만들기
	private String getPath(TreeExpansionEvent event) {
		StringBuffer path = new StringBuffer();
		TreePath treePath = event.getPath();
		Object[] list = treePath.getPath();
		for (int index = 1; index < list.length; index++) {
			path.append(((DefaultMutableTreeNode) list[index]).getUserObject() + "\\");
		}
		return path.toString();
	}

	public void treeWillExpand(TreeExpansionEvent event) {
		TreePath treePath = event.getPath();
		DefaultMutableTreeNode parentNode = (DefaultMutableTreeNode) treePath.getLastPathComponent();
		File parentFile = new File(getPath(event));
		File[] children = parentFile.listFiles();
		DefaultMutableTreeNode childNode;
		
		// 최상위 폴더일 때 
		if(parentNode.getUserObject().toString().equals("내 PC"))
		{
			return;
		}
		
		// 기존파일 초기회
		parentNode.removeAllChildren();
		
		// 하위 폴더 추가 
		for (File child : children) {
			if (child.isDirectory() && !child.isHidden() && Files.isReadable(child.toPath())) {
				childNode = new DefaultMutableTreeNode(child.getName());
				
				// 하위폴더의 하위폴더들 추가 
				File grandChildFile = new File(getPath(event) + child.getName() + "\\");
				addChild(grandChildFile,childNode);
				
				// 현재 폴더에 하위폴더 추가 
				parentNode.add(childNode);
			}
		}
	}

	@Override
	public void treeWillCollapse(TreeExpansionEvent event) throws ExpandVetoException {
		// TODO Auto-generated method stub

	}
	
}
