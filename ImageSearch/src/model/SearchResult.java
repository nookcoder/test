package model;

import java.util.List;

public class SearchResult {
    private List<Documents> documents;

    public SearchResult(List<Documents> documents) {
        this.documents = documents;
    }

    public List<Documents> getDocuments() {
        return documents;
    }
}
