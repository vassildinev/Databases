# Database Systems - Overview Homework #

----------
1. Hierarchical (tree), Network / graph, Relational (table), Object-oriented
2. To manage data stored in tables
3. A table in db terms is data, arranged in rows and columns
4. The primary key is a column of the table which uniquely identifies each row. The foreign key is an identifier for another set of data located at some other table. By specifying a foreign key for table the two tables are said to be related to one another, hence the term "relational"
5. Types of db relationships:
 - one-to-many: one data record can have many corresponding data records stored in another table, e.g country-towns
 - one-to-one: one data record has exactly and only one related data record from another table related to it, e.g student-score
 - many-to-many: many data records can correspond to many foreign data records, e.g. students-courses
 - self-relationship: data records point to data-records from the same table, e.g manager-employees
6. A database schema is said to be normalized if it describes table data such that it contains no repeating data records. In a sense, it provides uniqueness of the data
7. Integrity constraints provide a way to ensure the data stored conforms to certain rules
8. Indices speed up searching of values, but adding and deleting snippets of data is more or less slow
9. A language providing syntax for manipulating relational databases
10. Transactions are a sequence of logically related operations which require them to be executed as a single unit. If one of the sub-operations fails to be completed, every sub-operation action prior to it is in a sense reverted, so that the state of the changed objects are either their initial, or the expected final. Any intermediate state is strictly not allowed. A typical example is bank transfer - either all small operations during the transfer are executed successfully or the whole transfer is denied
11. Databases which are document-based and have no relations
12. Classical non-relational db models:
 - Key-Value Pair: Use the associative array as their fundamental data model
 - Document store: Assumes that each document encapsulate and encode data in some standard format or encoding
 - Graph: Suitable for data with undetermined number of relations between them (e.g social relations) which are well represented as a graph
 - Object model: Set of object-oriented style objects

(Source: blog.sphereinc.com/blog/2012/03/pros-and-cons-of-using-nosql-solutions)

13. NoSQL Databases:
 - Pros: Horizontal scalability (no complex joins => convenient parallel processing); Easy to use and modify; Saves time by providing no need to develop fine-grained data models
 - Cons: Possible db administration issues; Absence of standardization; Lack of powerful indexing support