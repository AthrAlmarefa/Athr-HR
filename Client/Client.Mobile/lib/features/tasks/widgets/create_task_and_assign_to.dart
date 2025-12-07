

 import 'package:athr_hr/core/localization/lang_keys.dart';
import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/core/styles/fonts/my_fonts.dart';
import 'package:athr_hr/core/utils/extension/my_context.dart';
import 'package:athr_hr/core/widgets/custom_text_form_field.dart';
import 'package:athr_hr/features/leaves/widgets/build_drop_down_list.dart';
import 'package:athr_hr/generated/assets.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class CreateTaskAndAssignTo extends StatefulWidget {
   const CreateTaskAndAssignTo({super.key});

   @override
   State<CreateTaskAndAssignTo> createState() => _CreateTaskAndAssignToState();
 }

 class _CreateTaskAndAssignToState extends State<CreateTaskAndAssignTo> {
   late TextEditingController taskNameController = TextEditingController();
   late TextEditingController assignToController = TextEditingController(
     text: context.translate(LangKeys.selectEmployee),
   );
   final GlobalKey taskNameKey = GlobalKey();
   final GlobalKey selectEmployeeKey = GlobalKey();
   @override
   Widget build(BuildContext context) {
     return Column(
       children: [
         Align(
           alignment: Alignment.centerRight,
           child: Text(
             context.translate(LangKeys.taskName),
             style: MyFonts.styleMedium500_16.copyWith(
               color: MyColors.black,
             ),
           ),
         ),
         SizedBox(height: 8.h),
         SizedBox(
           width: 398.w,
           height: 64.h,
           child: CustomTextFormField(
             key: taskNameKey,
             controller: taskNameController,
             hintText: context.translate(LangKeys.enterTaskName),
             hintStyle: MyFonts.semiBold600_18.copyWith(
               color: MyColors.black,
             ),
           ),
         ),
         SizedBox(height: 24.h),
         Align(
           alignment: Alignment.centerRight,
           child: Text(
             context.translate(LangKeys.assignTo),
             style: MyFonts.styleMedium500_16.copyWith(
               color: MyColors.black,
             ),
           ),
         ),
         SizedBox(height: 6.h),
         SizedBox(
           width: 398.w,
           height: 64.h,
           child: CustomTextFormField(
             controller: assignToController,
             readOnly: true,
             showCursor: false,
             key: selectEmployeeKey,
             textStyle: MyFonts.semiBold600_18.copyWith(
               color: MyColors.black,
             ),
             suffix: GestureDetector(
               onTap: () {
                 showLeaveDropdown(
                   context: context,
                   controller: assignToController,
                   options: [
                     context.translate(LangKeys.somaya),
                     context.translate(LangKeys.reem),
                     context.translate(LangKeys.mahitab),
                     context.translate(LangKeys.sara),
                   ],
                   fieldKey: selectEmployeeKey,
                 );
               },
               child: Image.asset(
                 Assets.imagesDropdownarrow,
                 width: 24.w,
                 height: 24.h,
                 fit: BoxFit.contain,
               ),
             ),
           ),
         ),
       ],
     );
   }
 }
