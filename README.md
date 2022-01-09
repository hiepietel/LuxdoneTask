# LuxdoneTask
Main Concept: 
The application should draw lines between two points selected by the user. The lines must be continuous, but not necessarily straight. The lines may not cross any lines previously drawn. 

New Version (branch: master): 

  - Detection of intersection was totally changed. 
  - Whole board points are placed in List of Tuple.
  - Added button to clean board
  - Added checkbox -> when checked: temp function are shown on the board

Todo: 
  - Improve algorithm to create Bezier lines (it is better than in alpha, but still can be improved)



Old Version (branch: alpha): 

What's working: 
  - Window,
  - Drawing lines, 
  - Drawing points.

Todo: 
  - Improve algorithm to detect intersection,
  - Improve algorithm to create Bezier lines.


Algorithm is based on: 
https://mat.polsl.pl/sjpam/zeszyty/z6/Silesian_J_Pure_Appl_Math_v6_i1_str_155-176.pdf
