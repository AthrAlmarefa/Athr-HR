import 'package:athr_hr/core/localization/lang_keys.dart';
import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/core/utils/extension/my_context.dart';
import 'package:athr_hr/core/widgets/dialog_helper.dart';
import 'package:athr_hr/features/profile/widgets/custom_elevated_button.dart';
import 'package:athr_hr/generated/assets.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class BuildButtonsRow extends StatefulWidget {
   const BuildButtonsRow({super.key});

   @override
   State<BuildButtonsRow> createState() => _BuildButtonsRowState();
 }

 class _BuildButtonsRowState extends State<BuildButtonsRow> {
   @override
   Widget build(BuildContext context) {
     return Row(
       mainAxisAlignment: MainAxisAlignment.spaceAround,
       children: [
         CustomElevatedButton(
     text: context.translate(LangKeys.edit),
     width: 150.w,
     height: 64.h,
     gradient: const LinearGradient(
     colors: [
     Color(0xCC1BABB6),
     Color(0xCC005157),
     ],
       begin: Alignment.bottomCenter,
       end: Alignment.topCenter,
     ),
     textColor: MyColors.white,
     borderRadius: 16,
     image: Assets.imagesEdittask,
     onPressed: () {},
     ),
         CustomElevatedButton(
           text:  context.translate(LangKeys.delete),
           width: 150.w,
           height: 64.h,
           backgroundColor: MyColors.redColor,
           textColor: MyColors.white,
           borderRadius: 16,
           image: Assets.imagesDeletetask,
           onPressed: (){
               showCustomConfirmDialog(
                 context: context,
                 title: context.translate(LangKeys.deleteTask),
                 message: context.translate(LangKeys.confirmDeleteTask),
                 cancelText: context.translate(LangKeys.cancel),
                 confirmText: context.translate(LangKeys.yesDelete),
                 cancelColor: MyColors.deleteColor,
                 confirmTextColor: MyColors.black,
                 confirmGradient: const LinearGradient(
                   colors: [
                     Color(0x08AF2D12),
                     Color(0x08AF2D12),
                   ],
                 ),
                 onCancel: () {
                   Navigator.pop(context);
                 },
                 onConfirm: () {
                 },
               );
             },
         ),
],
     );
   }
 }

