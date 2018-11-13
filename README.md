# DotMatrixDataDisplay

很久以前的一个项目，如果需要修改里面的点阵字库资源会有点麻烦，该工具可以把点阵字库简单的转换成可显示的字符串；

具体功能如下：

输入：

0x00, 0x0C, 0x00, 0x00, 0x07, 0x80, 0x00, 0x01, 0xE0, 0x00, 0x00, 0x38, 0x00, 0x00, 0x00, 0x00, 
0x00, 0x03, 0x00, 0x00, 0x01, 0xE0, 0x00, 0x00, 0xF8, 0x00, 0x00, 0x7F, 0x00, 0x00, 0x1F, 0xE0, 
0x00, 0x05, 0xFC, 0x00, 0x03, 0x7B, 0x80, 0x00, 0xDE, 0x20, 0x00, 0x07, 0x80, 0x00, 0x01, 0xE0, 
0x00, 0x00, 0x7C, 0x00, 0x00, 0x33, 0x00, 0x00, 0x0C, 0xC0, 0x00, 0x06, 0x30, 0x00, 0x03, 0x8E, 
0x00, 0x00, 0xC1, 0xC0, 0x00, 0x08, 0x00, 0x00

转换输出：

//                                     *  *                                     
//                                  *  *  *  *                                  
//                                  *  *  *  *                                  
//                                     *  *  *                                  
//                                                                              
//                                     *  *                                     
//                                  *  *  *  *                                  
//                               *  *  *  *  *                                  
//                            *  *  *  *  *  *  *                               
//                            *  *  *  *  *  *  *  *                            
//                            *     *  *  *  *  *  *  *                         
//                         *  *     *  *  *  *     *  *  *                      
//                         *  *     *  *  *  *           *                      
//                                  *  *  *  *                                  
//                                  *  *  *  *                                  
//                                  *  *  *  *  *                               
//                               *  *        *  *                               
//                               *  *        *  *                               
//                            *  *           *  *                               
//                         *  *  *           *  *  *                            
//                         *  *                 *  *  *                         
//                               *                                              