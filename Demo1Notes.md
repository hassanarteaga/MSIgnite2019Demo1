# Demo1Notes


- ### Be sure to use correct query to show most updated rows.....
  ```sh
  SELECT * FROM c where c.nlog_date>20190403000000
  ```

  ```sh
  SELECT VALUE COUNT(1) FROM c where c.nlog_date>20190403000000
  ```
